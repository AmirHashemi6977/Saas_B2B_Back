using Saas_B2B_Back.Application.ProductImage;
using Saas_B2B_Back.Application.ProductImage.Queries;
using Saas_B2B_Back.Domain.Entities;
using Saas_B2B_Back.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saas_B2B_Back.Application.ProductImage.Queries.Handler
{
    public class GetProductImageByIdQueryHandler : IRequestHandler<GetProductImageByIdQuery, ProductImagesResponse>
    {
        private readonly IGenericRepository<ProductImages, int> _repository;
        public GetProductImageByIdQueryHandler(IGenericRepository<ProductImages, int> repository)
        {
            _repository = repository;
        }

        public async Task<ProductImagesResponse> Handle(GetProductImageByIdQuery getProductImageByIdQuery, CancellationToken cancellationToken)
        {
            var productImage = await _repository.GetByIdAsync(getProductImageByIdQuery.Id);

            if (productImage is null)
            {
                throw new Exception("عکس محصول یافت نشد!");
            }

            var getProductImageRes = new ProductImagesResponse
            {
                Id = productImage.Id,
                ProductId = productImage.ProductId,
                Title = productImage.Title,
                Url = productImage.Url,
                IsMain = productImage.IsMain,
                InsertDate = productImage.InsertDate,
                UpdateDate = productImage.UpdateDate
            };

            return getProductImageRes;
        }


    }
}
