using Saas_B2B_Back.Domain.Entities;
using Saas_B2B_Back.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saas_B2B_Back.Application.ProductDetails.Commands.Handler
{
    public class DeleteProductDetailCommandHandler : IRequestHandler<DeleteProductDetailCommand, bool>
    {
        private readonly IGenericRepository<ProductImages, int> _repository;

        public DeleteProductDetailCommandHandler(IGenericRepository<ProductImages, int> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteProductDetailCommand deleteProductDetailCommand, CancellationToken cancellationToken)
        {
            var getProductDetail = await _repository.GetByIdAsync(deleteProductDetailCommand.Id);

            if (getProductDetail == null)
            {
               return false;
            }
            try
            {
                await _repository.DeleteAsync(getProductDetail.Id);
                return true;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
