using Core.API.Common;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : BaseController
    {
        public AuthenticationController(IMediator mediator)
            : base(mediator)
        {
        }

        [AllowAnonymous]
        [HttpPost("", Name = "CreateCustomer")]
        public Task<IActionResult> CreateCustomer()
        {
            return Task.FromResult(Ok() as IActionResult);
        }
    }
}
