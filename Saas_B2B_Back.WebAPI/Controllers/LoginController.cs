using Saas_B2B_Back.Application.Users;
using Saas_B2B_Back.Application.Users.Commands;
using Microsoft.AspNetCore.Mvc;

namespace Saas_B2B_Back.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class LoginController : BaseController
    {

        // Post: Login 
        [HttpPost]
        public async Task<ActionResult<UserResponse>> Login([FromBody] LoginUserCommand loginUserCommand)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var body = new LoginUserCommand
                {
                    Email = loginUserCommand.Email,
                    NationalCode = loginUserCommand.NationalCode,
                    PhoneNumber = loginUserCommand.PhoneNumber,
                    Password = loginUserCommand.Password,
                };

                var userLogined = await Mediator.Send(body);

                if (userLogined == null)
                {
                    return NotFound("کاربر یافت نشد!");
                }
                return Ok(userLogined);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"خطایی در ورود کاربر به وجود آمده است: {ex.Message}");
            }

        }
    }
}
