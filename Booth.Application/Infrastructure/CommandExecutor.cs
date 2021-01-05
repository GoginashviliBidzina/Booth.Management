using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using FluentValidation.Results;
using FluentValidation.Attributes;
using Booth.Infrastructure.DataBase;
using Booth.Domain.BoothManagement.Repository;
using Booth.Domain.ProductManagement.Repository;
using Booth.Domain.OrderManagement.Repositories;

namespace Booth.Application.Infrastructure
{
    public class CommandExecutor
    {
        protected DatabaseContext _db;
        protected UnitOfWork _unitOfWork;
        protected IServiceProvider _serviceProvider;
        protected IBoothRepository _boothRepository;
        protected IOrderRepository _orderRepository;
        protected IProductRepository _productRepository;

        public CommandExecutor(DatabaseContext db,
                               UnitOfWork unitOfWork,
                               IServiceProvider serviceProvider,
                               IBoothRepository boothRepository,
                               IOrderRepository orderRepository,
                               IProductRepository productRepository)
        {
            _db = db;
            _unitOfWork = unitOfWork;
            _serviceProvider = serviceProvider;
            _boothRepository = boothRepository;
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }

        public async Task<CommandExecutionResult> ExecuteAsync(Command command)
        {
            try
            {
                var validationResult = Validate(command);

                if (!validationResult.IsValid)
                {
                    return new CommandExecutionResult
                    {
                        Success = false,
                        ErrorCode = ErrorCode.ValidationFailed,
                        Errors = validationResult.Errors.Select(error => error.ErrorMessage)
                    };
                }

                command.Resolve(_db,
                              _unitOfWork,
                              _serviceProvider,
                              _boothRepository,
                              _orderRepository,
                              _productRepository);

                return await command.ExecuteAsync();
            }
            catch (Exception)
            {
                return new CommandExecutionResult
                {
                    Success = false,
                    ErrorCode = ErrorCode.Exception
                };
            }
        }

        public static ValidationResult Validate(Command execution)
        {
            var validatorAttribute = execution.GetType().GetCustomAttribute<ValidatorAttribute>(true);
            if (validatorAttribute != null)
            {
                var instance = (dynamic)Activator.CreateInstance(validatorAttribute.ValidatorType);
                var modelState = instance.Validate((dynamic)execution);
                return modelState;
            }

            return new ValidationResult();
        }
    }
}
