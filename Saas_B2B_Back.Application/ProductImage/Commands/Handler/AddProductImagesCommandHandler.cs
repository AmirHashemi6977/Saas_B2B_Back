using Saas_B2B_Back.Domain.Entities;
using Saas_B2B_Back.Domain.Interfaces;
using MediatR;

namespace Saas_B2B_Back.Application.ProductImage.Commands.Handler
{
    public class AddProductImagesCommandHandler : IRequestHandler<AddProductImagesCommand, ProductImagesResponse>
    {
        private readonly IGenericRepository<ProductImages, int> _productImageRepository;
        public AddProductImagesCommandHandler(IGenericRepository<ProductImages, int> productImageRepository, IGenericRepository<Product, int> productRepository)
        {
            _productImageRepository = productImageRepository;
        }

        public async Task<ProductImagesResponse> Handle(AddProductImagesCommand addProductImagesCommand, CancellationToken cancellationToken)
        {
            var productImages = new ProductImages
            {
                ProductId = addProductImagesCommand.ProductId,
                Url = addProductImagesCommand.Url,
                Title = addProductImagesCommand.Title,
                IsMain = addProductImagesCommand.IsMain,
                InsertDate = DateTime.UtcNow
            };

    
                var productImagesCreatedInDb = await _productImageRepository.AddAsync(productImages);

                if (productImagesCreatedInDb is null)
                {
                return null;
                }

                var productImagesRes = new ProductImagesResponse
                {

                    ProductId = productImagesCreatedInDb.ProductId,
                    Url = productImagesCreatedInDb.Url,
                    Title = productImagesCreatedInDb.Title,
                    IsMain = productImagesCreatedInDb.IsMain,
                    InsertDate = productImagesCreatedInDb.InsertDate
                };

                return productImagesRes;

         



        }


    }


}

