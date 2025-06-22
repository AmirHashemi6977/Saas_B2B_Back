using Saas_B2B_Back.Application.Users;
using Saas_B2B_Back.Application.Users.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Saas_B2B_Back.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    
    public class ForgotPasswordController : BaseController
    {

        // Post: api/ResetPassword 
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<string>> ForgotPassword([FromBody] ForgotPasswordUserCommand resetPasswordUserCommand)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var body = new ForgotPasswordUserCommand
                {
                    Email = resetPasswordUserCommand.Email,
                    PhoneNumber = resetPasswordUserCommand.PhoneNumber,
                };

                var newPass = await Mediator.Send(body);

                if (newPass == null)
                {
                    return NotFound("کاربر یافت نشد!");
                }
                return Ok(newPass);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"خطایی در فراموشی رمز عبور به وجود آمده است: {ex.Message}");
            }

        }
    }
}
