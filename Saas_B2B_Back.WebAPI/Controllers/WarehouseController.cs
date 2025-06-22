

using Saas_B2B_Back.Application.Warehouses.Commands;
using Saas_B2B_Back.Application.Warehouses.Queries;
using Saas_B2B_Back.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Saas_B2B_Back.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class WarehouseController : BaseController
    {


        // GET: Warehouses getWarehouses
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<Warehouse>> GetAllWarehouses(CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                //var allWarehouses = await Mediator.Send(getAllWarehouseQuery);
                var getAllWarehousesQuery = new GetAllWarehouseQuery();
                var allWarehouses = await Mediator.Send(getAllWarehousesQuery);

                if (allWarehouses == null)
                {
                    return NotFound("هیچ انباری یافت نشد!");
                 
                }
                return Ok(allWarehouses);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"خطایی در دریافت اطلاعات انبار به وجود آمده است: {ex.Message}");
            }
        }



        // GET: Warehouses/5  get Warehouse
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<Warehouse>> GetWarehouseById([FromQuery] int id, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var getWarehouseByIdQuery = new GetWarehouseByIdQuery(id);
                var selectedWarehouse = await Mediator.Send(getWarehouseByIdQuery);

                
                if (selectedWarehouse == null)
                {
                    return NotFound("انبار یافت نشد!");
                }
                return Ok(selectedWarehouse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"خطایی در دریافت اطلاعات انبار به وجود آمده است: {ex.Message}");
            }
        }



        // Post: Warehouses Add
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Warehouse>> AddWarehouse([FromBody] AddWarehouseCommand addWarehouseCommand, CancellationToken cancellationToken)

        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {

                var Warehouse = await Mediator.Send(addWarehouseCommand, cancellationToken);

                if (Warehouse is null)
                {
                    return StatusCode(500, $"خطایی در افزودن انبار به وجود آمده است");
                }
                return Ok(Warehouse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"خطایی در افزودن انبار به وجود آمده است: {ex.Message}");
            }

        }

        // Put: Warehouse/id Update
        [HttpPut]
        [Authorize]
        public async Task<ActionResult<Warehouse>> UpdateWarehouse([FromBody] UpdateWarehouseCommand updateWarehouseCommand, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {

                var updatedWarehouse = await Mediator.Send(updateWarehouseCommand);

                if (updatedWarehouse == null)
                {
                    return NotFound("انبار یافت نشد!");
                }
                return Ok(updatedWarehouse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"خطایی در ویرایش انبار به وجود آمده است: {ex.Message}");
            }
        }

        // Delete: Warehouse/5 Delete
        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> DeleteWarehouseById([FromBody] DeleteWarehouseCommand deleteWarehouseCommand, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {

                var deletedWarehouse = await Mediator.Send(deleteWarehouseCommand);

                if (deletedWarehouse == false)
                {
                    return NotFound("انبار یافت نشد!");
                }
                return Ok(deletedWarehouse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"خطایی در حذف انبار به وجود آمده است: {ex.Message}");
            }
        }


    }
}
