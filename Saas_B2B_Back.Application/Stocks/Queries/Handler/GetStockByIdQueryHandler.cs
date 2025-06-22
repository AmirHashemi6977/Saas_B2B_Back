using Saas_B2B_Back.Domain.Entities;
using Saas_B2B_Back.Domain.Interfaces;
using MediatR;


namespace Saas_B2B_Back.Application.Stocks.Queries.Handler
{
    public class GetStockByIdQueryHandler : IRequestHandler<GetStockByIdQuery, StockResponse>
    {
        private readonly IGenericRepository<Stock, int> _repository;
        public GetStockByIdQueryHandler(IGenericRepository<Stock, int> repository)
        {
            _repository = repository;
        }

        public async Task<StockResponse> Handle(GetStockByIdQuery getStockByIdQuery, CancellationToken cancellationToken)
        {
            var Stock = await _repository.GetByIdAsync(getStockByIdQuery.Id);

            if (Stock is null)
            {
               return null;
            }

            var getStockRes = new StockResponse {
                Id = Stock.Id, 
                ProductDetailId = Stock.ProductDetailId,
                Quantity = Stock.Quantity,
                WastedQuantity= Stock.WastedQuantity,
                WarehouseId = Stock.WarehouseId,
                InsertDate = Stock.InsertDate, UpdateDate = Stock.UpdateDate };

            return getStockRes;
        }


    }
}
