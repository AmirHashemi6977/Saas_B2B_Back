using Saas_B2B_Back.Domain.Entities;
using Saas_B2B_Back.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saas_B2B_Back.Application.Orders.Commands.Handler
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, bool>
    {
        private readonly IGenericRepository<Order,long> _repository;

        public DeleteOrderCommandHandler(IGenericRepository<Order, long> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteOrderCommand deleteOrderCommand, CancellationToken cancellationToken)
        {
            var getOrder = await _repository.GetByIdAsync(deleteOrderCommand.Id);

            if (getOrder == null)
            {
                return false;
            }
            try
            {
                await _repository.DeleteAsync(getOrder.Id);
                return true;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
