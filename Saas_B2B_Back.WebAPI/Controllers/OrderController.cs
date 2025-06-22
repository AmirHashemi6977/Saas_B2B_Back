
using Saas_B2B_Back.Application.Orders.Commands;
using Saas_B2B_Back.Application.Orders.Queries;
using Saas_B2B_Back.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;



namespace Saas_B2B_Back.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class OrderController : BaseController
    {


  // GET: Orders getOrders
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<Order>> GetAllOrders(CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                //var allOrders = await Mediator.Send(getAllOrderQuery);
                var getAllOrdersQuery = new GetAllOrderQuery();
                var allOrders = await Mediator.Send(getAllOrdersQuery);

                if (allOrders == null)
                {
                    return NotFound("هیچ سفارشی یافت نشد!");

                }
                return Ok(allOrders);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"خطایی در دریافت اطلاعات سفارش به وجود آمده است: {ex.Message}");
            }
        }



        // GET: Orders/5  get Order
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<Order>> GetOrderById([FromQuery] long id, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var getOrderByIdQuery = new GetOrderByIdQuery(id);
                var selectedOrder = await Mediator.Send(getOrderByIdQuery);


                if (selectedOrder == null)
                {
                    return NotFound("سفارش یافت نشد!");
                }
                return Ok(selectedOrder);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"خطایی در دریافت اطلاعات سفارش به وجود آمده است: {ex.Message}");
            }
        }



        // Post: Orders Add
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Order>> AddOrder([FromBody] AddOrderCommand addOrderCommand, CancellationToken cancellationToken)

        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {

                var Order = await Mediator.Send(addOrderCommand, cancellationToken);

                if (Order is null)
                {
                    return StatusCode(500, $"خطایی در افزودن سفارش به وجود آمده است");
                }
                return Ok(Order);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"خطایی در افزودن سفارش به وجود آمده است: {ex.Message}");
            }

        }

        // Put: Order/id Update
        [HttpPut]
        [Authorize]
        public async Task<ActionResult<Order>> UpdateOrder([FromBody] UpdateOrderCommand updateOrderCommand, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {

                var updatedOrder = await Mediator.Send(updateOrderCommand);

                if (updatedOrder == null)
                {
                    return NotFound("سفارش یافت نشد!");
                }
                return Ok(updatedOrder);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"خطایی در ویرایش سفارش به وجود آمده است: {ex.Message}");
            }
        }

        // Delete: Order/5 Delete
        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> DeleteOrderById([FromBody] DeleteOrderCommand deleteOrderCommand, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {

                var deletedOrder = await Mediator.Send(deleteOrderCommand);

                if (deletedOrder == false)
                {
                    return NotFound("سفارش یافت نشد!");
                }
                return Ok(deletedOrder);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"خطایی در حذف سفارش به وجود آمده است: {ex.Message}");
            }
        }


    }
}


    