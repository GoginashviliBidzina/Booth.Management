using System.Linq;
using FluentValidation;
using System.Threading.Tasks;
using System.Collections.Generic;
using FluentValidation.Attributes;
using Microsoft.EntityFrameworkCore;
using Booth.Application.Infrastructure;
using Booth.Domain.ProductManagement.ReadModels;

namespace Booth.Application.Queries.Product
{
    [Validator(typeof(ProductListingQueryValidator))]
    public class ProductListingQuery : Query<ProductListingQueryResult>
    {
        public int BoothId { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public decimal MinPrice { get; set; }

        public decimal MaxPrice { get; set; }

        public int PageSize { get; set; }

        public int PageIndex { get; set; }

        public async override Task<QueryExecutionResult<ProductListingQueryResult>> ExecuteAsync()
        {
            var products = await _db.Set<ProductReadModel>()
                                    .Where(product =>
                                           (string.IsNullOrWhiteSpace(Name) ? true : product.Name.Contains(Name)) &&
                                           (string.IsNullOrWhiteSpace(Code) ? true : product.Code.Contains(Code)) &&
                                           (MinPrice < MaxPrice && MinPrice > 0 && MaxPrice > 0 ? true : product.Price < MaxPrice && product.Price > MinPrice)
                                    )
                                    .Skip(PageSize * PageIndex)
                                    .Take(PageSize)
                                    .ToListAsync();

            var listing = products.Select(product => new ProductListing(product.Id,
                                                                        product.AggregateRootId,
                                                                        product.Code,
                                                                        product.Name,
                                                                        product.Description,
                                                                        product.Price,
                                                                        product.SupplierId,
                                                                        product.PhotoUrl,
                                                                        product.PhotoWidth,
                                                                        product.PhotoHeight));

            var result = new ProductListingQueryResult(listing.Count() < PageSize,
                                                       products.Count(),
                                                       listing);

            return await OkAsync(result);
        }
    }

    internal class ProductListingQueryValidator : AbstractValidator<ProductListingQuery>
    {
        public ProductListingQueryValidator()
        {
            RuleFor(product => product.BoothId)
                .GreaterThan(0)
                .WithMessage("BoothId should be greater than zero.");
        }
    }

    public class ProductListing
    {
        public int Id { get; set; }

        public int AggregateRootId { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int SupplierId { get; set; }

        public string PhotoUrl { get; set; }

        public int PhotoWidth { get; set; }

        public int PhotoHeight { get; set; }

        public ProductListing(int id,
                              int aggregateRootId,
                              string code,
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
            Code = code;
            Description = description;
            Price = price;
            SupplierId = supplierId;
            PhotoUrl = photoUrl;
            PhotoWidth = photoWidth;
            PhotoHeight = photoHeight;
        }
    }

    public class ProductListingQueryResult
    {
        public bool IsLastPage { get; set; }

        public int TotalCount { get; set; }

        public IEnumerable<ProductListing> ProductListing { get; set; }

        public ProductListingQueryResult(bool isLastPage,
                                         int totalCount,
                                         IEnumerable<ProductListing> productListing)
        {
            IsLastPage = isLastPage;
            TotalCount = totalCount;
            ProductListing = productListing;
        }
    }
}
