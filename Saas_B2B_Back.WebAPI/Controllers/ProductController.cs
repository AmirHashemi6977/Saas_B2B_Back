

using Saas_B2B_Back.Application.Products.Commands;
using Saas_B2B_Back.Application.Products.Queries;
using Saas_B2B_Back.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Saas_B2B_Back.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProductController : BaseController
    {


        // GET: Products getProducts
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<Product>> GetAllProducts(CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                //var allProducts = await Mediator.Send(getAllProductQuery);
                var getAllProductsQuery = new GetAllProductQuery();
                var allProducts = await Mediator.Send(getAllProductsQuery);

                if (allProducts == null)
                {
                    return NotFound("هیچ محصولی یافت نشد!");
                 
                }
                return Ok(allProducts);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"خطایی در دریافت اطلاعات محصولات به وجود آمده است: {ex.Message}");
            }
        }



        // GET: products/5  get Product
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<Product>> GetProductById([FromQuery] int id, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var getProductByIdQuery = new GetProductByIdQuery(id);
                var selectedProduct = await Mediator.Send(getProductByIdQuery);

                
                if (selectedProduct == null)
                {
                    return NotFound("محصول یافت نشد!");
                }
                return Ok(selectedProduct);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"خطایی در دریافت اطلاعات محصول به وجود آمده است: {ex.Message}");
            }
        }



        // Post: Products Add
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Product>> AddProduct([FromBody] AddProductCommand addProductCommand, CancellationToken cancellationToken)

        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {

                var product = await Mediator.Send(addProductCommand, cancellationToken);

                if (product is null)
                {
                    return StatusCode(500, $"خطایی در افزودن محصول به وجود آمده است");
                }
                return Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"خطایی در افزودن محصول به وجود آمده است: {ex.Message}");
            }

        }

        // Put: Product/id Update
        [HttpPut]
        [Authorize]
        public async Task<ActionResult<Product>> UpdateProduct([FromBody] UpdateProductCommand updateProductCommand, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {

                var updatedProduct = await Mediator.Send(updateProductCommand);

                if (updatedProduct == null)
                {
                    return NotFound("محصول یافت نشد!");
                }
                return Ok(updatedProduct);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"خطایی در ویرایش محصول به وجود آمده است: {ex.Message}");
            }
        }

        // Delete: Product/5 Delete
        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> DeleteProductById([FromBody] DeleteProductCommand deleteProductCommand, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {

                var deletedProduct = await Mediator.Send(deleteProductCommand);

                if (deletedProduct == false)
                {
                    return NotFound("محصول یافت نشد!");
                }
                return Ok(deletedProduct);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"خطایی در حذف محصول به وجود آمده است: {ex.Message}");
            }
        }


    }
}
