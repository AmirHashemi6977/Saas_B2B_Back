

using Saas_B2B_Back.Application.Stocks.Commands;
using Saas_B2B_Back.Application.Stocks.Queries;
using Saas_B2B_Back.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Saas_B2B_Back.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class StockController : BaseController
    {


        // GET: Stocks getStocks
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<Stock>> GetAllStocks(CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                //var allStocks = await Mediator.Send(getAllStockQuery);
                var getAllStocksQuery = new GetAllStockQuery();
                var allStocks = await Mediator.Send(getAllStocksQuery);

                if (allStocks == null)
                {
                    return NotFound("هیچ موجودی کالایی یافت نشد!");
                 
                }
                return Ok(allStocks);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"خطایی در دریافت اطلاعات موجودی کالا به وجود آمده است: {ex.Message}");
            }
        }



        // GET: Stocks/5  get Stock
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<Stock>> GetStockById([FromQuery] int id, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var getStockByIdQuery = new GetStockByIdQuery(id);
                var selectedStock = await Mediator.Send(getStockByIdQuery);

                
                if (selectedStock == null)
                {
                    return NotFound("موجودی کالا یافت نشد!");
                }
                return Ok(selectedStock);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"خطایی در دریافت اطلاعات موجودی کالا به وجود آمده است: {ex.Message}");
            }
        }



        // Post: Stocks Add
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Stock>> AddStock([FromBody] AddStockCommand addStockCommand, CancellationToken cancellationToken)

        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {

                var Stock = await Mediator.Send(addStockCommand, cancellationToken);

                if (Stock is null)
                {
                    return StatusCode(500, $"خطایی در افزودن موجودی کالا به وجود آمده است");
                }
                return Ok(Stock);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"خطایی در افزودن موجودی کالا به وجود آمده است: {ex.Message}");
            }

        }

        // Put: Stock/id Update
        [HttpPut]
        [Authorize]
        public async Task<ActionResult<Stock>> UpdateStock([FromBody] UpdateStockCommand updateStockCommand, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {

                var updatedStock = await Mediator.Send(updateStockCommand);

                if (updatedStock == null)
                {
                    return NotFound("موجودی کالا یافت نشد!");
                }
                return Ok(updatedStock);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"خطایی در ویرایش موجودی کالا به وجود آمده است: {ex.Message}");
            }
        }

        // Delete: Stock/5 Delete
        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> DeleteStockById([FromBody] DeleteStockCommand deleteStockCommand, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {

                var deletedStock = await Mediator.Send(deleteStockCommand);

                if (deletedStock == false)
                {
                    return NotFound("موجودی کالا یافت نشد!");
                }
                return Ok(deletedStock);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"خطایی در حذف موجودی کالا به وجود آمده است: {ex.Message}");
            }
        }


    }
}
