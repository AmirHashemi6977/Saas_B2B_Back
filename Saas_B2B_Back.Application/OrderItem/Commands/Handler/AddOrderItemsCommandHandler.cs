
using Saas_B2B_Back.Domain.Entities;
using Saas_B2B_Back.Domain.Interfaces;
using MediatR;



namespace Saas_B2B_Back.Application.OrderItem.Commands
{
    public class AddOrderItemsCommandHandler : IRequestHandler<AddOrderItemsCommandList, List<OrderItemsResponse>>
    {
        private readonly IGenericRepository<OrderItems, long> _repository;
        public AddOrderItemsCommandHandler(IGenericRepository<OrderItems, long> repository)
        {
            _repository = repository;
        }


        public async Task<List<OrderItemsResponse>> Handle(AddOrderItemsCommandList addOrderItemsCommandList, CancellationToken cancellationToken)
        {

            var responses = new List<OrderItems>();

            foreach (var item in addOrderItemsCommandList.Item)
            {
                var response = new OrderItems
                {
                    OrderId = item.OrderId,
                    ProductId = item.ProductId,
                    Unit = item.Unit,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice,
                    Amount = item.Amount,
                    NetAmount = item.NetAmount,
                    DiscountAmount = item.DiscountAmount,
                    DiscountPercent = item.DiscountPercent,
                    ExtraAmount = item.ExtraAmount,
                    TaxAmount = item.TaxAmount,
                    PayableAmount = item.PayableAmount,

                };

                responses.Add(response);

            }


            try
            {
                var OrderItemsCreatedInDb = await _repository.AddListAsync(responses);

                var OrderItemsRes = new List<OrderItemsResponse>();


                foreach (var item in OrderItemsCreatedInDb)
                {
                    OrderItemsRes.Add(
                        new OrderItemsResponse
                        {
                            Id = item.Id,
                            OrderId = item.OrderId,
                            ProductId = item.ProductId,
                            Unit = item.Unit,
                            Quantity = item.Quantity,
                            UnitPrice = item.UnitPrice,
                            Amount = item.Amount,
                            NetAmount = item.NetAmount,
                            DiscountAmount = item.DiscountAmount,
                            DiscountPercent = item.DiscountPercent,
                            ExtraAmount = item.ExtraAmount,
                            TaxAmount = item.TaxAmount,
                            PayableAmount = item.PayableAmount,
                            InsertDate = item.InsertDate,
                        }
                          );
                }


                return OrderItemsRes;
            }
            catch (Exception ex)
            {
                return null;
            }

        }





    }


}

