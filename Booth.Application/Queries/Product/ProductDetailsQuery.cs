using System;
using System.Linq;
using FluentValidation;
using System.Threading.Tasks;
using Booth.Application.Helpers;
using FluentValidation.Attributes;
using Microsoft.EntityFrameworkCore;
using Booth.Application.Infrastructure;
using Booth.Domain.ProductManagement.ReadModels;

namespace Booth.Application.Queries.Product
{
    [Validator(typeof(ProductDetailsQueryValidator))]
    public class ProductDetailsQuery : Query<ProductDetailsQueryResult>
    {
        public int Id { get; set; }

        public int BoothId { get; set; }

        public async override Task<QueryExecutionResult<ProductDetailsQueryResult>> ExecuteAsync()
        {
            var product = await _db.Set<ProductReadModel>()
                                   .FirstOrDefaultAsync(prod => prod.AggregateRootId == Id &&
                                                        prod.BoothIds.ToNewArray().Contains(BoothId));

            if (product == null)
                return await FailAsync(ErrorCode.NotFound);

            return await OkAsync(new ProductDetailsQueryResult(product.Id,
                                                               product.AggregateRootId,
                                                               product.Name,
                                                               product.Description,
                                                               product.Price,
                                                               product.SupplierId,
                                                               product.PhotoUrl,
                                                               product.PhotoWidth,
                                                               product.PhotoHeight));
        }
    }

    internal class ProductDetailsQueryValidator : AbstractValidator<ProductDetailsQuery>
    {
        public ProductDetailsQueryValidator()
        {
            RuleFor(product => product.Id)
                .GreaterThan(0)
                .WithMessage("Id should be greater than zero.");

            RuleFor(product => product.BoothId)
                .GreaterThan(0)
                .WithMessage("Id should be greater than zero.");
        }
    }

    public class ProductDetailsQueryResult
    {
        public int Id { get; set; }

        public int AggregateRootId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int SupplierId { get; set; }

        public string PhotoUrl { get; set; }

        public int PhotoWidth { get; set; }

        public int PhotoHeight { get; set; }

        public ProductDetailsQueryResult(int id,
                                         int aggregateRootId,
                                         string name,
                                         string description,
                                         decimal price,
                                         int supplierId,
                                         string photoUrl,
                                         int photoWidth,
                                         int photoHeight)
        {
            Id = id;
            AggregateRootId = aggregateRootId;
            Name = name;
            Description = description;
            Price = price;
            SupplierId = supplierId;
            PhotoUrl = photoUrl;
            PhotoWidth = photoWidth;
            PhotoHeight = photoHeight;
        }
    }
}
