

using Saas_B2B_Back.Application.ProductDetails.Commands;
using Saas_B2B_Back.Application.ProductDetails.Queries;
using Saas_B2B_Back.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Saas_B2B_Back.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProductDetailController : BaseController
    {


        // GET: ProductDetails getProductDetails
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<ProductDetail>> GetAllProductDetails(CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                //var allProductDetails = await Mediator.Send(getAllProductDetailQuery);
                var getAllProductDetailsQuery = new GetAllProductDetailQuery();
                var allProductDetails = await Mediator.Send(getAllProductDetailsQuery);

                if (allProductDetails == null)
                {
                    return NotFound("هیچ جزئیات جزئیات محصولی یافت نشد!");

                }
                return Ok(allProductDetails);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"خطایی در دریافت اطلاعات جزئیات جزئیات محصولات به وجود آمده است: {ex.Message}");
            }
        }



        // GET: ProductDetails/5  get ProductDetail
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<ProductDetail>> GetProductDetailById([FromQuery] int id, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var getProductDetailByIdQuery = new GetProductDetailByIdQuery(id);
                var selectedProductDetail = await Mediator.Send(getProductDetailByIdQuery);


                if (selectedProductDetail == null)
                {
                    return NotFound("جزئیات محصول یافت نشد!");
                }
                return Ok(selectedProductDetail);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"خطایی در دریافت اطلاعات جزئیات محصول به وجود آمده است: {ex.Message}");
            }
        }



        // Post: ProductDetails Add
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<ProductDetail>> AddProductDetail([FromBody] AddProductDetailCommand addProductDetailCommand, CancellationToken cancellationToken)

        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {

                var ProductDetail = await Mediator.Send(addProductDetailCommand, cancellationToken);

                if (ProductDetail is null)
                {
                    return StatusCode(500, $"خطایی در افزودن جزئیات محصول به وجود آمده است");
                }
                return Ok(ProductDetail);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"خطایی در افزودن جزئیات محصول به وجود آمده است: {ex.Message}");
            }

        }

        // Put: ProductDetail/id Update
        [HttpPut]
        [Authorize]
        public async Task<ActionResult<ProductDetail>> UpdateProductDetail([FromBody] UpdateProductDetailCommand updateProductDetailCommand, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {

                var updatedProductDetail = await Mediator.Send(updateProductDetailCommand);

                if (updatedProductDetail == null)
                {
                    return NotFound("جزئیات محصول یافت نشد!");
                }
                return Ok(updatedProductDetail);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"خطایی در ویرایش جزئیات محصول به وجود آمده است: {ex.Message}");
            }
        }

        // Delete: ProductDetail/5 Delete
        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> DeleteProductDetailById([FromBody] DeleteProductDetailCommand deleteProductDetailCommand, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {

                var deletedProductDetail = await Mediator.Send(deleteProductDetailCommand);

                if (deletedProductDetail == false)
                {
                    return NotFound("جزئیات محصول یافت نشد!");
                }
                return Ok(deletedProductDetail);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"خطایی در حذف جزئیات محصول به وجود آمده است: {ex.Message}");
            }
        }


    }
}
