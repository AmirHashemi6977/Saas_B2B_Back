using Saas_B2B_Back.Application.ProductImage;
using Saas_B2B_Back.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saas_B2B_Back.Application.ProductImage.Queries
{
    public record class GetProductImageByIdQuery : IRequest<ProductImagesResponse>
    {
        public int Id { get; set; }
        public GetProductImageByIdQuery(int id)
        {
            Id = id;
        }
    }
}
