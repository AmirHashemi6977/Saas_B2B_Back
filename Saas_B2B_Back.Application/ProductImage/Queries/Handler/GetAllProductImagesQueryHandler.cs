

using Saas_B2B_Back.Domain.Entities;
using Saas_B2B_Back.Domain.Interfaces;
using MediatR;

namespace Saas_B2B_Back.Application.ProductImage.Queries.Handler
{
    public class GetAllProductImagesQueryHandler : IRequestHandler<GetAllProductImagesQuery, List<ProductImagesResponse>>
    {
        private readonly IGenericRepository<ProductImages, int> _repository;
        public GetAllProductImagesQueryHandler(IGenericRepository<ProductImages, int> repository)
        {
            _repository = repository;
        }

        public async Task<List<ProductImagesResponse>> Handle(GetAllProductImagesQuery getAllProductImagesQuery, CancellationToken cancellationToken)
        {
            var getAllProductImages = await _repository.GetAllAsync();

            if (getAllProductImages is null)
            {
                throw new Exception("هیچ عکسی برای محصولات یافت نشد!");
            }

            return getAllProductImages
                .Select(productImage =>
                new ProductImagesResponse
                {
                    Id = productImage.Id,
                    ProductId = productImage.ProductId,
                    Url = productImage.Url,
                    Title = productImage.Title,
                    IsMain = productImage.IsMain,
                    InsertDate = productImage.InsertDate,
                    UpdateDate = productImage.UpdateDate
                })
                .ToList();
        }
    }
}
