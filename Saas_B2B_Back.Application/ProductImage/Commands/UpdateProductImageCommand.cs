using Saas_B2B_Back.Application.ProductImage;
using Saas_B2B_Back.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saas_B2B_Back.Application.ProductImage.Commands
{

    public class UpdateProductImageCommand : IRequest<ProductImagesResponse>
    {
        public long Id { get; set; }

        public string? Title { get; set; }

        public string? Url { get; set; }

        public bool? IsMain { get; set; }
    }

}

