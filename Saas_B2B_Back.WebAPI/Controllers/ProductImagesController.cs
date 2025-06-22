
using Saas_B2B_Back.Application.Common.Exceptions;
using Saas_B2B_Back.Application.ProductImage.Commands;
using Saas_B2B_Back.Application.ProductImage.Queries;
using Saas_B2B_Back.Application.Orders.Commands;
using Saas_B2B_Back.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Saas_B2B_Back.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProductImagesController : BaseController
    {


        // GET: ProductImages getProductImages
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<ProductImages>> GetAllProductImages(CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var getAllProductImagesQuery = new GetAllProductImagesQuery();
                var allProductImages = await Mediator.Send(getAllProductImagesQuery);

                if (allProductImages == null)
                {
                    return NotFound("هیچ عکس کالایی یافت نشد!");
                }
                return Ok(allProductImages);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"خطایی در دریافت اطلاعات عکس کالا به وجود آمده است: {ex.Message}");
            }
        }



        // GET: ProductImages/5  get Product
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<ProductImages>> GetProductById([FromQuery] int id, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var getProductImagesByIdQuery = new GetProductImageByIdQuery(id);
                    var selectedProduct = await Mediator.Send(getProductImagesByIdQuery);


                if (selectedProduct == null)
                {
                    return NotFound("عکس کالا یافت نشد!");

                }
                return Ok(selectedProduct);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"خطایی در دریافت اطلاعات عکس کالا به وجود آمده است: {ex.Message}");
            }
        }



        // Post: ProductImages Add
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<ProductImages>> AddProduct([FromBody] AddProductImagesCommand addProductImagesCommand, CancellationToken cancellationToken)

        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {

                var productImages = await Mediator.Send(addProductImagesCommand, cancellationToken);

                if (productImages is null)
                {
                    return NotFound("عکس کالا یافت نشد!");
                }
                return Ok(productImages);
            }
            catch (Errors ex)
            {
                return StatusCode(500, $"خطایی در افزودن عکس کالا به وجود آمده است: {ex.Message}");
            }

        }

        // Put: Product/id Update
        [HttpPut]
        [Authorize]
        public async Task<ActionResult<ProductImages>> UpdateProduct([FromBody] UpdateProductImageCommand updateProductImageCommand, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {

                var selectedProductImage = await Mediator.Send(updateProductImageCommand);

                if (selectedProductImage == null)
                {
                    return NotFound("عکس کالا یافت نشد!");
                }
                return Ok(selectedProductImage);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"خطایی در ویرایش عکس کالا به وجود آمده است: {ex.Message}");
            }
        }

        // Delete: Product/5 Delete
        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> DeleteProductById([FromBody] DeleteProductImagesCommand deleteProductImagesCommand, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {

                var selectedProductImages = await Mediator.Send(deleteProductImagesCommand);

                if (selectedProductImages == null)
                {
                    return NotFound("عکس کالا یافت نشد!");
                }
                return Ok(selectedProductImages);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"خطایی در حذف عکس کالا به وجود آمده است: {ex.Message}");
            }
        }


    }
}
