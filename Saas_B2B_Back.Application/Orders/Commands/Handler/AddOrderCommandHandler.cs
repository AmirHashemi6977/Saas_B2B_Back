
using Saas_B2B_Back.Domain.Entities;
using Saas_B2B_Back.Domain.Interfaces;
using MediatR;


namespace Saas_B2B_Back.Application.Orders.Commands
{
    public class AddOrderCommandHandler : IRequestHandler<AddOrderCommand, OrderResponse>
    {
        private readonly IGenericRepository<Order, long> _repository;
        public AddOrderCommandHandler(IGenericRepository<Order, long> repository)
        {
            _repository = repository;
        }

        public async Task<OrderResponse> Handle(AddOrderCommand addOrderCommand, CancellationToken cancellationToken)
        {
            var Order = new Order {
            DeliveryDate=addOrderCommand.DeliveryDate,
            OrderStatus=addOrderCommand.OrderStatus,
            TotalPrice=addOrderCommand.TotalPrice,
            UserId = addOrderCommand.UserId 
            };

            try
            {
            var orderCreatedInDb = await _repository.AddAsync(Order);

                var OrderRes = new OrderResponse
                {
                    Id = orderCreatedInDb.Id,
                    UserId=orderCreatedInDb.UserId,
                    TotalPrice = orderCreatedInDb.TotalPrice,
                    OrderStatus = orderCreatedInDb.OrderStatus,
                    DeliveryDate = orderCreatedInDb.DeliveryDate,
                    InsertDate = orderCreatedInDb.InsertDate
                };
                return OrderRes;
            }
            catch (Exception ex)
            {
                return null;
            }

          
           
        }


    }


}

