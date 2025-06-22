using Saas_B2B_Back.Application.ProductImage;
using Saas_B2B_Back.Domain.Entities;
using Saas_B2B_Back.Domain.Interfaces;
using MediatR;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Saas_B2B_Back.Application.ProductDetails.Commands.Handler
{

    public class UpdateProductDetailCommandHandler : IRequestHandler<UpdateProductDetailCommand, ProductDetailResponse>
    {
        private readonly IGenericRepository<ProductDetail, int> _repository;

        public UpdateProductDetailCommandHandler(IGenericRepository<ProductDetail, int> repository)
        {
            _repository = repository;
        }

        public async Task<ProductDetailResponse> Handle(UpdateProductDetailCommand updateProductDetailCommand, CancellationToken cancellationToken)
        {

            var productDetailInDB = await _repository.GetByIdAsync(updateProductDetailCommand.Id);

            if (productDetailInDB == null)
            {
                return null;
            }


            productDetailInDB.WatteringMethod = updateProductDetailCommand.WatteringMethod is null ? productDetailInDB.WatteringMethod : updateProductDetailCommand.WatteringMethod;
            productDetailInDB.WatteringAmount = updateProductDetailCommand.WatteringAmount is null ? productDetailInDB.WatteringAmount : updateProductDetailCommand.WatteringAmount;
            productDetailInDB.Description = updateProductDetailCommand.Description is null ? productDetailInDB.Description : updateProductDetailCommand.Description;
            productDetailInDB.Price = updateProductDetailCommand.Price is null ? productDetailInDB.Price : updateProductDetailCommand.Price;
            productDetailInDB.Color = updateProductDetailCommand.Color is null ? productDetailInDB.Color : updateProductDetailCommand.Color;
            productDetailInDB.Material = updateProductDetailCommand.Material is null ? productDetailInDB.Material : updateProductDetailCommand.Material;
            productDetailInDB.Dimension = updateProductDetailCommand.Dimension is null ? productDetailInDB.Dimension : updateProductDetailCommand.Dimension;
            productDetailInDB.SunAmount = updateProductDetailCommand.SunAmount is null ? productDetailInDB.SunAmount : updateProductDetailCommand.SunAmount;
            productDetailInDB.Weight = updateProductDetailCommand.Weight is null ? productDetailInDB.Weight : updateProductDetailCommand.Weight;
            productDetailInDB.UpdateDate = DateTime.UtcNow;


            try
            {


                var updatedInDb = await _repository.UpdateAsync(productDetailInDB);

                var productDetailRes = new ProductDetailResponse
                {
                    Id = updatedInDb.Id,
                    WatteringMethod = updatedInDb.WatteringMethod,
                    WatteringAmount = updatedInDb.WatteringAmount,
                    Description = updatedInDb.Description,
                    Price = updatedInDb.Price,
                    Color = updatedInDb.Color,
                    Material = updatedInDb.Material,
                    Dimension = updatedInDb.Dimension,
                    SunAmount = updatedInDb.SunAmount,
                    Weight = updatedInDb.Weight,
                    UpdateDate = updatedInDb.UpdateDate

                };

                return productDetailRes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }
    }

}
