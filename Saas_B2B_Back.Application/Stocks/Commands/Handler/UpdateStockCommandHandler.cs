using Saas_B2B_Back.Domain.Entities;
using Saas_B2B_Back.Domain.Interfaces;
using MediatR;

namespace Saas_B2B_Back.Application.Stocks.Commands
{

    public class UpdateStockCommandHandler : IRequestHandler<UpdateStockCommand, StockResponse>
    {
        private readonly IGenericRepository<Stock, int> _repository;

        public UpdateStockCommandHandler(IGenericRepository<Stock, int> repository)
        {
            _repository = repository;
        }

        public async Task<StockResponse> Handle(UpdateStockCommand updateStockCommand, CancellationToken cancellationToken)
        {

            var StockToUpdate = await _repository.GetByIdAsync(updateStockCommand.Id);

            if (StockToUpdate == null)
            {
                return null;
            }


            StockToUpdate.ProductDetailId = updateStockCommand.ProductDetailId is null ? StockToUpdate.ProductDetailId : (long)updateStockCommand.ProductDetailId;
            StockToUpdate.WarehouseId = updateStockCommand.WarehouseId is null ? StockToUpdate.WarehouseId : (int)updateStockCommand.WarehouseId;
            StockToUpdate.Quantity = updateStockCommand.Quantity is null ? StockToUpdate.Quantity : (int)updateStockCommand.Quantity;
            StockToUpdate.WastedQuantity = updateStockCommand.WastedQuantity is null ? StockToUpdate.WastedQuantity : (int)updateStockCommand.WastedQuantity;
            StockToUpdate.UpdateDate = DateTime.UtcNow;


            try
            {
                var updatedStock = await _repository.UpdateAsync(StockToUpdate);

                var StockRes = new StockResponse
                {
                    Id = updatedStock.Id,
                    WastedQuantity = updatedStock.WastedQuantity,
                    Quantity = updatedStock.Quantity,
                    WarehouseId = updatedStock.WarehouseId,
                    ProductDetailId = updatedStock.ProductDetailId,
                    UpdateDate = updatedStock.UpdateDate,
                    InsertDate= updatedStock.InsertDate
                };


                return StockRes;


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }
    }

}
