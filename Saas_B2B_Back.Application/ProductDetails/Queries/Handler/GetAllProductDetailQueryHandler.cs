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

    public class GetAllProductDetailQueryHandler : IRequestHandler<GetAllProductDetailQuery, List<ProductDetailResponse>>
    {
        private readonly IGenericRepository<ProductDetail, int> _repository;
        public GetAllProductDetailQueryHandler(IGenericRepository<ProductDetail, int> repository)
        {
            _repository = repository;
        }

        public async Task<List<ProductDetailResponse>> Handle(GetAllProductDetailQuery getAllProductDetailQuery, CancellationToken cancellationToken)
        {
            var getAllProductDetails = await _repository.GetAllAsync();

            if (getAllProductDetails is null)
            {
                return null;
            }

            return getAllProductDetails
                .Select(productDetail =>
                new ProductDetailResponse
                {
                    Id = productDetail.Id,
                    ProductId = productDetail.ProductId,
                    Dimension = productDetail.Dimension,
                    Material = productDetail.Material,
                    Price = productDetail.Price,
                    SunAmount = productDetail.SunAmount,
                    WatteringAmount = productDetail.WatteringAmount,
                    WatteringMethod = productDetail.WatteringMethod,
                    Weight = productDetail.Weight,
                    Color=productDetail.Color,
                    Description = productDetail.Description,
                    InsertDate = productDetail.InsertDate,
                    UpdateDate = productDetail.UpdateDate
                })
                .ToList();
        }
    }

}
