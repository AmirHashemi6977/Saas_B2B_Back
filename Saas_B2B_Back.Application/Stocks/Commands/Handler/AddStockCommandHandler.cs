
using Saas_B2B_Back.Domain.Entities;
using Saas_B2B_Back.Domain.Interfaces;
using MediatR;


namespace Saas_B2B_Back.Application.Stocks.Commands
{
    public class AddStockCommandHandler : IRequestHandler<AddStockCommand, StockResponse>
    {
        private readonly IGenericRepository<Stock, int> _repository;
        public AddStockCommandHandler(IGenericRepository<Stock, int> repository)
        {
            _repository = repository;
        }

        public async Task<StockResponse> Handle(AddStockCommand addStockCommand, CancellationToken cancellationToken)
        {
            var Stock = new Stock { 
            ProductDetailId=addStockCommand.ProductDetailId ,
            WarehouseId= (int)addStockCommand.WarehouseId! ,
            Quantity = addStockCommand.Quantity ,
            WastedQuantity = addStockCommand.WastedQuantity 
            
            };

            try
            {
                var stockCreatedInDb = await _repository.AddAsync(Stock);

                var StockRes = new StockResponse
                {
                    Id = stockCreatedInDb.Id,
                    ProductDetailId = stockCreatedInDb.ProductDetailId,
                    WarehouseId = stockCreatedInDb.WarehouseId!,
                    Quantity = stockCreatedInDb.Quantity,
                    WastedQuantity = stockCreatedInDb.WastedQuantity,
                    InsertDate = stockCreatedInDb.InsertDate
                };

                return StockRes;
            }
            catch (Exception ex)
            {
                return null;
            }



        }


    }


}

