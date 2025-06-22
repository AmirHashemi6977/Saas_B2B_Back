
using Saas_B2B_Back.Domain.Entities;
using Saas_B2B_Back.Domain.Interfaces;
using MediatR;


namespace Saas_B2B_Back.Application.Products.Commands
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommand, ProductResponse>
    {
        private readonly IGenericRepository<Product, int> _repository;
        public AddProductCommandHandler(IGenericRepository<Product, int> repository)
        {
            _repository = repository;
        }

        public async Task<ProductResponse> Handle(AddProductCommand addProductCommand, CancellationToken cancellationToken)
        {
            var product = new Product { Name = addProductCommand.Name, Description = addProductCommand.Description };

            try
            {
                var prdodutCreatedInDb = await _repository.AddAsync(product);

                var productRes = new ProductResponse
                {
                    Id = prdodutCreatedInDb.Id,
                    Name = prdodutCreatedInDb.Name,
                    Description = prdodutCreatedInDb.Description,
                    InsertDate = prdodutCreatedInDb.InsertDate
                };
                return productRes;
            }
            catch (Exception ex)
            {
                return null;
            }



        }


    }


}

