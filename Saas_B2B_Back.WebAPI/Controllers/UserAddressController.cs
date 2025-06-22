
using Saas_B2B_Back.Application.Users;
using Saas_B2B_Back.Application.Users.Commands;
using Saas_B2B_Back.Application.Users.Queries;
using Saas_B2B_Back.Application.Users.Queries.Handler;
using Saas_B2B_Back.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Saas_B2B_Back.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UserAddressController:BaseController
    {

        // GET: UserAddresses Get AllUser

       [HttpGet]
        [Authorize]
        public async Task<ActionResult<UserAddressesResponse>> GetAllUserAddresses()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var UserAddresses = new GetAllUserAddressesQuery();
                var allUserAddresses = await Mediator.Send(UserAddresses);

                if (allUserAddresses == null)
                {
                    return NotFound();
                }
                return Ok(allUserAddresses);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"خطایی در دریافت اطلاعات آدرس کاربران به وجود آمده است: {ex.Message}");
            }
        }



        // GET: UserAddresses/5 Get UserAddressById
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<UserAddressesResponse>> GetUserAddressesById([FromQuery] long id, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var getUserAddresses = new GetUserAddressesByIdQuery(id);

                var selectedUserAddresses = await Mediator.Send(getUserAddresses);

                if (selectedUserAddresses == null)
                {
                    return NotFound();
                }
                return Ok(selectedUserAddresses);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"خطایی در دریافت اطلاعات کاربر به وجود آمده است: {ex.Message}");
            }
        }

        // Post: UserAddresses Add
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<UserAddressesResponse>> AddUser([FromBody] AddUserAddressesCommand addUserAddressesCommand)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var body = new AddUserAddressesCommand {
                    UserId = addUserAddressesCommand.UserId,
                    Address = addUserAddressesCommand.Address,
                    Area = addUserAddressesCommand.Area,
                    City = addUserAddressesCommand.City,    
                    PostalCode = addUserAddressesCommand.PostalCode

                   
                };
                var selectedUserAddresses = await Mediator.Send(body);

                if (selectedUserAddresses == null)
                {
                    return NotFound();
                }
                return Ok(selectedUserAddresses);
            }
            catch(Exception ex)
            {
                return StatusCode(500, $"خطایی در افزودن کاربر به وجود آمده است: {ex.Message}");
            }
            
        }

        // Put: UserAddresses Update
        [HttpPut]
        [Authorize]
        public async Task<ActionResult<UserAddressesResponse>> UpdateUserAddress([FromBody] UpdateUserAddressesCommand updateUserAddressesCommand)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var selectedUserAddress = await Mediator.Send(updateUserAddressesCommand);

                if (selectedUserAddress == null)
                {
                    return NotFound();
                }
                return Ok(selectedUserAddress);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"خطایی در ویرایش آدرس کاربر به وجود آمده است: {ex.Message}");
            }
        }

        // Delete: UserAddresses/5 Delete
        [HttpDelete]
        [Authorize]
        public async Task<ActionResult<bool>> DeleteUserById([FromBody] DeleteUserAddressesCommand deleteUserAddressesCommand)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var isDeleted = await Mediator.Send(deleteUserAddressesCommand);

                if (isDeleted == false)
                {
                    return NotFound();
                }
                return Ok(isDeleted);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"خطایی در حذف آدرس کاربر به وجود آمده است: {ex.Message}");
            }
        }
    }
}
