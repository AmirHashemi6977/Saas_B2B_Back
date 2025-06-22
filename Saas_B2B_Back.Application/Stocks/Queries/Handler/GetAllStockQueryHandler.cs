
using Saas_B2B_Back.Domain.Entities;
using Saas_B2B_Back.Domain.Interfaces;
using MediatR;

namespace Saas_B2B_Back.Application.Stocks.Queries.Handler
{
    public class GetAllStockQueryHandler : IRequestHandler<GetAllStockQuery, List<StockResponse>>
    {
        private readonly IGenericRepository<Stock, int> _repository;
        public GetAllStockQueryHandler(IGenericRepository<Stock, int> repository)
        {
            _repository = repository;
        }

        public async Task<List<StockResponse>> Handle(GetAllStockQuery getAllStockQuery, CancellationToken cancellationToken)
        {
            var getStocks = await _repository.GetAllAsync();

            if (getStocks is null)
            {
                return null;
            }

            return getStocks
                .Select(Stock =>
                new StockResponse
                {
                    Id = Stock.Id,
                    ProductDetailId = Stock.ProductDetailId,
                    WarehouseId = Stock.WarehouseId,
                    Quantity = Stock.Quantity,
                    WastedQuantity = Stock.WastedQuantity,
                    InsertDate = Stock.InsertDate,
                    UpdateDate = Stock.UpdateDate
                }
                )
                .ToList();
        }
    }
}
