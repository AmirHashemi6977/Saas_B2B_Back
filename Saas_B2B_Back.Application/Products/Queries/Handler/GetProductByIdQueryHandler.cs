using Saas_B2B_Back.Domain.Entities;
using Saas_B2B_Back.Domain.Interfaces;
using MediatR;


namespace Saas_B2B_Back.Application.Products.Queries.Handler
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductResponse>
    {
        private readonly IGenericRepository<Product, int> _repository;
        public GetProductByIdQueryHandler(IGenericRepository<Product, int> repository)
        {
            _repository = repository;
        }

        public async Task<ProductResponse> Handle(GetProductByIdQuery getProductByIdQuery, CancellationToken cancellationToken)
        {
            var product = await _repository.GetByIdAsync(getProductByIdQuery.Id);

            if (product is null)
            {
               return null;
            }

            var getProductRes = new ProductResponse { Id = product.Id, Name = product.Name, Description = product.Description, InsertDate = product.InsertDate, UpdateDate = product.UpdateDate };

            return getProductRes;
        }


    }
}
