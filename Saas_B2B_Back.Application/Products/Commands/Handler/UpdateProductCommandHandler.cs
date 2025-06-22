using Saas_B2B_Back.Domain.Entities;
using Saas_B2B_Back.Domain.Interfaces;
using MediatR;

namespace Saas_B2B_Back.Application.Products.Commands
{

    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ProductResponse>
    {
        private readonly IGenericRepository<Product, long> _repository;

        public UpdateProductCommandHandler(IGenericRepository<Product, long> repository)
        {
            _repository = repository;
        }

        public async Task<ProductResponse> Handle(UpdateProductCommand updateProductCommand, CancellationToken cancellationToken)
        {

            var productToUpdate = await _repository.GetByIdAsync(updateProductCommand.Id);

            if (productToUpdate == null)
            {
                return null;
            }


            productToUpdate.Name = updateProductCommand.Name;
            productToUpdate.Description = updateProductCommand.Description;
            productToUpdate.UpdateDate = DateTime.UtcNow;


            try
            {
                var updatedProduct = await _repository.UpdateAsync(productToUpdate);

                var productRes = new ProductResponse
                {
                    Id = updatedProduct.Id,
                    Name = updatedProduct.Name,
                    Description = updatedProduct.Description,
                    UpdateDate = updatedProduct.UpdateDate
                };


                return productRes;


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }
    }

}
