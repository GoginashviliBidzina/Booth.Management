using System;
using System.Reflection;
using System.Threading.Tasks;
using FluentValidation.Results;
using FluentValidation.Attributes;
using Booth.Infrastructure.DataBase;
using Booth.Domain.BoothManagement.Repository;
using Booth.Domain.OrderManagement.Repositories;
using Booth.Domain.ProductManagement.Repository;

namespace Booth.Application.Infrastructure
{
    public class QueryExecutor
    {
        protected DatabaseContext _db;
        protected UnitOfWork _unitOfWork;
        protected IServiceProvider _serviceProvider;
        protected IBoothRepository _boothRepository;
        protected IOrderRepository _orderRepository;
        protected IProductRepository _productRepository;

        public QueryExecutor(DatabaseContext db,
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

        public async Task<QueryExecutionResult<TResult>> ExecuteAsync<TQuery, TResult>(TQuery query)
            where TQuery : Query<TResult>
            where TResult : class
        {
            try
            {
                var validationResult = Validate(query);

                if (!validationResult.IsValid)
                {
                    return new QueryExecutionResult<TResult>
                    {
                        Success = false,
                        ErrorCode = ErrorCode.ValidationFailed
                    };
                }

                query.Resolve(_db,
                              _unitOfWork,
                              _serviceProvider,
                              _boothRepository,
                              _orderRepository,
                              _productRepository);

                return await query.ExecuteAsync();
            }
            catch (Exception)
            {
                return new QueryExecutionResult<TResult>
                {
                    Success = false,
                    ErrorCode = ErrorCode.Exception
                };
            }
        }

        public static ValidationResult Validate<TResult>(Query<TResult> execution) where TResult : class
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
