using Saas_B2B_Back.Application.ProductImage;
using Saas_B2B_Back.Domain.Entities;
using MediatR;

namespace Saas_B2B_Back.Application.ProductImage.Commands
{
    public record class AddProductImagesCommand : IRequest<ProductImagesResponse>
    {
        public int ProductId { get; set; }
        public string? Url { get; set; }
        public required string Title { get; set; }

        public bool IsMain { get; set; }

    }
}
