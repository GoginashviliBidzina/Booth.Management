using System;
using Booth.Infrastructure.DataBase;
using Booth.Domain.BoothManagement.Repository;
using Booth.Domain.OrderManagement.Repositories;
using Booth.Domain.ProductManagement.Repository;

namespace Booth.Application.Infrastructure
{
    public abstract class ApplicationBase
    {
        protected DatabaseContext _db;
        protected UnitOfWork _unitOfWork;
        protected IServiceProvider _serviceProvider;
        protected IBoothRepository _boothRepository;
        protected IOrderRepository _orderRepository;
        protected IProductRepository _productRepository;

        public void Resolve(DatabaseContext db,
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

        public T GetService<T>() => (T)_serviceProvider.GetService(typeof(T));
    }
}
