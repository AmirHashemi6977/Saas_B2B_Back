using Saas_B2B_Back.Domain.Entities;
using Saas_B2B_Back.Domain.Interfaces;
using MediatR;


namespace Saas_B2B_Back.Application.Products.Commands.Handler
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, bool>
    {
        private readonly IGenericRepository<Product,int> _repository;

        public DeleteProductCommandHandler(IGenericRepository<Product, int> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteProductCommand deleteProductCommand, CancellationToken cancellationToken)
        {
            var getProduct = await _repository.GetByIdAsync(deleteProductCommand.Id);

            if (getProduct == null)
            {
                return false;
            }
            try
            {
                await _repository.DeleteAsync(getProduct.Id);
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
