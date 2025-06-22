using Saas_B2B_Back.Domain.Entities;
using Saas_B2B_Back.Domain.Interfaces;
using MediatR;


namespace Saas_B2B_Back.Application.Orders.Commands.Handler
{
    public class DeleteProductImagesCommandHandler : IRequestHandler<DeleteProductImagesCommand, bool>
    {
        private readonly IGenericRepository<ProductImages,long> _repository;

        public DeleteProductImagesCommandHandler(IGenericRepository<ProductImages, long> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteProductImagesCommand deleteProductImagesCommand, CancellationToken cancellationToken)
        {
            var getProductImages = await _repository.GetByIdAsync(deleteProductImagesCommand.Id);

            if (getProductImages == null)
            {
                return false;
            }
            try
            {
                await _repository.DeleteAsync(getProductImages.Id);
                return true;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
