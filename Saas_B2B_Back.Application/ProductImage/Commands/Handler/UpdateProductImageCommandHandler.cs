using Saas_B2B_Back.Domain.Entities;
using Saas_B2B_Back.Domain.Interfaces;
using MediatR;

namespace Saas_B2B_Back.Application.ProductImage.Commands.Handler
{

    public class UpdateProductImageCommandHandler : IRequestHandler<UpdateProductImageCommand, ProductImagesResponse>
    {
        private readonly IGenericRepository<ProductImages, long> _repository;

        public UpdateProductImageCommandHandler(IGenericRepository<ProductImages, long> repository)
        {
            _repository = repository;
        }

        public async Task<ProductImagesResponse> Handle(UpdateProductImageCommand updateProductCommand, CancellationToken cancellationToken)
        {

            var productImageInDB = await _repository.GetByIdAsync(updateProductCommand.Id);

            if (productImageInDB == null)
            {
                return null;
            }



            productImageInDB.Url = updateProductCommand.Url is null ? productImageInDB.Url : updateProductCommand.Url;
            productImageInDB.Title = updateProductCommand.Title is null ? productImageInDB.Title : updateProductCommand.Title;
            productImageInDB.IsMain = updateProductCommand.IsMain is null ? productImageInDB.IsMain : updateProductCommand.IsMain;
            productImageInDB.UpdateDate = DateTime.UtcNow;

            try
            {

                var updatedInDb = await _repository.UpdateAsync(productImageInDB);

                var productImageRes = new ProductImagesResponse
                {
                    Id = updatedInDb.Id,
                    Url = updatedInDb.Url,
                    Title = updatedInDb.Title,
                    IsMain = updatedInDb.IsMain,
                    UpdateDate = updatedInDb.UpdateDate
                };

                return productImageRes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }




        }
    }

}
