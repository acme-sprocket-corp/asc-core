using Core.API.Common;
using Core.Application.Customers.AddCustomer;
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
        public async Task<IActionResult> CreateCustomer(AddCustomerRequest request)
        {
            return await Execute(request, ResponseOptions.OkObject);
        }
    }
}
