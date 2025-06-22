using Saas_B2B_Back.Application.ProductImage;
using Saas_B2B_Back.Domain.Entities;
using Saas_B2B_Back.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saas_B2B_Back.Application.ProductDetails.Commands.Handler
{
    public class AddProductDetailCommandHandler : IRequestHandler<AddProductDetailCommand, ProductDetailResponse>
    {
        private readonly IGenericRepository<ProductDetail, int> _repository;
        public AddProductDetailCommandHandler(IGenericRepository<ProductDetail, int> repository)
        {
            _repository = repository;
        }

        public async Task<ProductDetailResponse> Handle(AddProductDetailCommand addProductDetailCommand, CancellationToken cancellationToken)
        {
            var productDetail = new ProductDetail
            {
                ProductId = addProductDetailCommand.ProductId,
                WatteringMethod = addProductDetailCommand.WatteringMethod,
                WatteringAmount = addProductDetailCommand.WatteringAmount,
                Description = addProductDetailCommand.Description,
                Price = addProductDetailCommand.Price,
                Color = addProductDetailCommand.Color,
                Material = addProductDetailCommand.Material,
                Dimension = addProductDetailCommand.Dimension,
                SunAmount = addProductDetailCommand.SunAmount,
                Weight = addProductDetailCommand.Weight,
                InsertDate = DateTime.UtcNow
            };

            var productDetailCreatedInDb = await _repository.AddAsync(productDetail);

            if (productDetailCreatedInDb is null)
            {
                return null;
            }

            var productDetailRes = new ProductDetailResponse
            {

                ProductId = productDetailCreatedInDb.ProductId,
                WatteringMethod = productDetailCreatedInDb.WatteringMethod,
                WatteringAmount = productDetailCreatedInDb.WatteringAmount,
                Description = productDetailCreatedInDb.Description,
                Price = productDetailCreatedInDb.Price,
                Color = productDetailCreatedInDb.Color,
                Material = productDetailCreatedInDb.Material,
                Dimension = productDetailCreatedInDb.Dimension,
                SunAmount = productDetailCreatedInDb.SunAmount,
                Weight = productDetailCreatedInDb.Weight,
                InsertDate = DateTime.UtcNow
            };

            return productDetailRes;
        }


    }


}

