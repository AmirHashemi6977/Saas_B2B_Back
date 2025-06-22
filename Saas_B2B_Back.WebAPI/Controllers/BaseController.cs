using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Saas_B2B_Back.WebAPI.Controllers
{
    [ApiController]
    public abstract class BaseController:ControllerBase
    {

        private  ISender? _mediator;
        protected ISender Mediator=> _mediator??= HttpContext.RequestServices.GetRequiredService<ISender>();

        
    }
}

