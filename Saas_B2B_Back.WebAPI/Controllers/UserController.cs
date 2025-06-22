using Saas_B2B_Back.Application.Orders.Commands;
using Saas_B2B_Back.Application.Users;
using Saas_B2B_Back.Application.Users.Commands;
using Saas_B2B_Back.Application.Users.Queries;
using Saas_B2B_Back.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Saas_B2B_Back.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UserController : BaseController
    {

        // GET: Users Get AllUser

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<UserResponse>> GetAllUsers()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var users = new GetAllUserQuery();
                var allUsers = await Mediator.Send(users);

                if (allUsers == null)
                {
                    return NotFound("هیچ کاربری یافت نشد!");
                }
                return Ok(allUsers);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"خطایی در دریافت اطلاعات کاربران به وجود آمده است: {ex.Message}");
            }
        }



        // GET: Users/5 Get UserById
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<UserResponse>> GetUserById([FromQuery] long id, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var getUser = new GetUserByIdQuery(id);

                var selectedUser = await Mediator.Send(getUser);

                if (selectedUser == null)
                {
                    return NotFound("کاربر یافت نشد!");

                }
                return Ok(selectedUser);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"خطایی در دریافت اطلاعات کاربر به وجود آمده است: {ex.Message}");
            }
        }



        // Post: Users Add
        [HttpPost]
      
        public async Task<ActionResult<UserResponse>> AddUser([FromBody] RegisterUserCommand registerUserCommand)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var body = new RegisterUserCommand {

                    Firstname = registerUserCommand.Firstname,
                    Lastname = registerUserCommand.Lastname,
                    PhoneNumber = registerUserCommand.PhoneNumber,
                    Email = registerUserCommand.Email,
                    Password = registerUserCommand.Password,
                    ConfirmPassword = registerUserCommand.ConfirmPassword,
                    SexCode = registerUserCommand.SexCode,
                    NationalCode = registerUserCommand.NationalCode,
                    UserGroupId = registerUserCommand.UserGroupId,
                    IsProvider = registerUserCommand.IsProvider,
                };
                var selectedUser = await Mediator.Send(body);

              
                return Ok(selectedUser);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"خطایی در افزودن کاربر به وجود آمده است: {ex.Message}");
            }

        }




        // Put: Users Update
        [HttpPut]
        [Authorize]
        public async Task<ActionResult<User>> UpdateUser([FromBody] UpdateUserCommand updateUserCommand, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {

                var selectedUser = await Mediator.Send(updateUserCommand);

                if (selectedUser == null)
                {
                    return NotFound("کاربر یافت نشد!");

                }
                return Ok(selectedUser);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"خطایی در ویرایش کاربر به وجود آمده است: {ex.Message}");
            }
        }





        // Delete: Users/5 Delete
        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> DeleteUserById([FromQuery] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var selectedUser=new DeleteUserCommand ( id);
                var isDeletedUser = await Mediator.Send(selectedUser);

                if (isDeletedUser == false)
                {
                    return NotFound("کاربر یافت نشد!");

                }
                return Ok(isDeletedUser);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"خطایی در حذف کاربر به وجود آمده است: {ex.InnerException}");
            }
        }

        // Post: Users/ChangePassword 
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<bool>> ChangePassword([FromBody] ChangePasswordUserCommand changePasswordUserCommand)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var body = new ChangePasswordUserCommand
                {
                   Id=changePasswordUserCommand.Id,
                   Password = changePasswordUserCommand.Password,
                   NewPassword = changePasswordUserCommand.NewPassword,
                   ConfirmPassword = changePasswordUserCommand.ConfirmPassword
                };

                var userLogined = await Mediator.Send(body);

                if (userLogined == false)
                {
                    return NotFound("کاربر یافت نشد!");
                }
                return Ok(userLogined);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"خطایی در تغییر رمز عبور کاربر به وجود آمده است: {ex.Message}");
            }

        }
    }
}
