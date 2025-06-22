using Saas_B2B_Back.Application.ProductImage;
using Saas_B2B_Back.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saas_B2B_Back.Application.ProductDetails.Queries
{
    public record class GetProductDetailByIdQuery : IRequest<ProductDetailResponse>
    {
        public int Id { get; set; }
        public GetProductDetailByIdQuery(int id)
        {
            Id = id;
        }
    }
}
