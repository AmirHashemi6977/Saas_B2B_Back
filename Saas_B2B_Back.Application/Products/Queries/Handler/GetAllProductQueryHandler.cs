
using Saas_B2B_Back.Domain.Entities;
using Saas_B2B_Back.Domain.Interfaces;
using MediatR;

namespace Saas_B2B_Back.Application.Products.Queries.Handler
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, List<ProductResponse>>
    {
        private readonly IGenericRepository<Product, int> _repository;
        public GetAllProductQueryHandler(IGenericRepository<Product, int> repository)
        {
            _repository = repository;
        }

        public async Task<List<ProductResponse>> Handle(GetAllProductQuery getAllProductQuery, CancellationToken cancellationToken)
        {
            var getProducts = await _repository.GetAllAsync();

            if (getProducts is null)
            {
                return null;
            }

            return getProducts
                .Select(product =>
                new ProductResponse
                { Id = product.Id, Name = product.Name, Description = product.Description, InsertDate = product.InsertDate, UpdateDate = product.UpdateDate })
                .ToList();
        }
    }
}
