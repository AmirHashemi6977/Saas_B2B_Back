using Saas_B2B_Back.Application.ProductImage;
using Saas_B2B_Back.Application.Orders.Commands;
using Saas_B2B_Back.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saas_B2B_Back.Application.ProductImage.Queries
{
    public record class GetAllProductImagesQuery : IRequest<List<ProductImagesResponse>>
    {
      
    }
}
