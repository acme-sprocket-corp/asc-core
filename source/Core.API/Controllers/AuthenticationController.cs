using Core.API.Common;
using Core.Application.Customers.AddCustomer;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ProducesResponseType(typeof(IEnumerable<string>), StatusCodes.Status400BadRequest)]
    public class AuthenticationController : BaseController
    {
        public AuthenticationController(IMediator mediator)
            : base(mediator)
        {
        }

        [AllowAnonymous]
        [HttpPost("", Name = "AddCustomer")]
        [ProducesResponseType(typeof(AddCustomerResponse), StatusCodes.Status201Created)]
        public async Task<IActionResult> AddCustomer(AddCustomerRequest request)
        {
            return await Execute(request, ResponseOptions.OkResponse);
        }
    }
}
