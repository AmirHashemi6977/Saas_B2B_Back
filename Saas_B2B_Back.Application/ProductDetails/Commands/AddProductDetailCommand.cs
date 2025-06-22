using Saas_B2B_Back.Application.ProductDetails;
using Saas_B2B_Back.Application.ProductImage;
using Saas_B2B_Back.Domain.Entities;
using MediatR;

namespace Saas_B2B_Back.Application.ProductDetails.Commands
{
    public record class AddProductDetailCommand : IRequest<ProductDetailResponse>
    {
        public int ProductId { get; set; }
        public string? Dimension { get; set; }

        public string? Weight { get; set; }

        public string? WatteringAmount { get; set; }

        public string? WatteringMethod { get; set; }

        public string? SunAmount { get; set; }

        public string? Material { get; set; }

        public decimal? Price { get; set; }

        public string? Color { get; set; }

        public string? Description { get; set; }


    }
}
