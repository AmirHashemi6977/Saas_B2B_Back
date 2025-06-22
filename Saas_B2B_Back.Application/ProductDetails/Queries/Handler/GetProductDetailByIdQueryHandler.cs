using Saas_B2B_Back.Application.ProductImage.Queries;
using Saas_B2B_Back.Application.ProductImage;
using Saas_B2B_Back.Domain.Entities;
using Saas_B2B_Back.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saas_B2B_Back.Application.ProductDetails.Queries.Handler
{

    public class GetProductDetailByIdQueryHandler : IRequestHandler<GetProductDetailByIdQuery, ProductDetailResponse>
    {
        private readonly IGenericRepository<ProductDetail, int> _repository;
        public GetProductDetailByIdQueryHandler(IGenericRepository<ProductDetail, int> repository)
        {
            _repository = repository;
        }

        public async Task<ProductDetailResponse> Handle(GetProductDetailByIdQuery getProductDetailByIdQuery, CancellationToken cancellationToken)
        {
            var productDetail = await _repository.GetByIdAsync(getProductDetailByIdQuery.Id);

            if (productDetail is null)
            {
                return null;
            }

            var getProductDetailRes = new ProductDetailResponse
            {
                ProductId = productDetail.ProductId,
                Id = productDetail.Id,
                Weight = productDetail.Weight,
                WatteringMethod = productDetail.WatteringMethod,
                WatteringAmount = productDetail.WatteringAmount,
                Dimension = productDetail.Dimension,
                Material = productDetail.Material,
                Price = productDetail.Price,
                SunAmount = productDetail.SunAmount,
                Color = productDetail.Color,
                Description= productDetail.Description, 
                InsertDate = productDetail.InsertDate,
                UpdateDate = productDetail.UpdateDate
            };

            return getProductDetailRes;
        }


    }

}
