
using Saas_B2B_Back.Application.OrderItem.Commands;
using Saas_B2B_Back.Application.OrderItem.Queries;
using Saas_B2B_Back.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;



namespace Saas_B2B_Back.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class OrderItemsController : BaseController
    {


        // GET: OrderItems getOrderItems
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<OrderItems>> GetAllOrderItems(CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                //var allOrderItems = await Mediator.Send(getAllOrderItemsQuery);
                var getAllOrderItemsQuery = new GetAllOrderItemsQuery();
                var allOrderItems = await Mediator.Send(getAllOrderItemsQuery);

                if (allOrderItems == null)
                {
                    return NotFound("هیچ جزئیات سفارشی یافت نشد!");

                }
                return Ok(allOrderItems);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"خطایی در دریافت اطلاعات جزئیات سفارش به وجود آمده است: {ex.Message}");
            }
        }



        // GET: OrderItems/5  get OrderItems
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<OrderItems>> GetOrderItemsById([FromQuery] long id, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var getOrderItemsByIdQuery = new GetOrderItemsByIdQuery(id);
                var selectedOrderItems = await Mediator.Send(getOrderItemsByIdQuery);


                if (selectedOrderItems == null)
                {
                    return NotFound("جزئیات سفارش یافت نشد!");
                }
                return Ok(selectedOrderItems);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"خطایی در دریافت اطلاعات جزئیات سفارش به وجود آمده است: {ex.Message}");
            }
        }



        // Post: OrderItems Add
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<OrderItems>> AddOrderItems([FromBody] AddOrderItemsCommandList addOrderItemsCommandList, CancellationToken cancellationToken)

        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {

                var OrderItems = await Mediator.Send(addOrderItemsCommandList, cancellationToken);

                if (OrderItems is null)
                {
                    return StatusCode(500, $"خطایی در افزودن جزئیات سفارش به وجود آمده است");
                }
                return Ok(OrderItems);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"خطایی در افزودن جزئیات سفارش به وجود آمده است: {ex.Message}");
            }

        }

        // Put: OrderItems/id Update
        [HttpPut]
        [Authorize]
        public async Task<ActionResult<OrderItems>> UpdateOrderItems([FromBody] UpdateOrderItemsCommand updateOrderItemsCommand, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {

                var updatedOrderItems = await Mediator.Send(updateOrderItemsCommand);

                if (updatedOrderItems == null)
                {
                    return NotFound("جزئیات سفارش یافت نشد!");
                }
                return Ok(updatedOrderItems);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"خطایی در ویرایش جزئیات سفارش به وجود آمده است: {ex.Message}");
            }
        }

        // Delete: OrderItems/5 Delete
        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> DeleteOrderItemsById([FromBody] DeleteOrderItemsCommand deleteOrderItemsCommand, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {

                var deletedOrderItems = await Mediator.Send(deleteOrderItemsCommand);

                if (deletedOrderItems == false)
                {
                    return NotFound("جزئیات سفارش یافت نشد!");
                }
                return Ok(deletedOrderItems);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"خطایی در حذف جزئیات سفارش به وجود آمده است: {ex.Message}");
            }
        }


    }
}


