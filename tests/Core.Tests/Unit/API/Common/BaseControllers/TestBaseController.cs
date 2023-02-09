using Core.API.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Core.Tests.Unit.API.Common.BaseControllers
{
    public class TestBaseController : BaseController
    {
        public TestBaseController(IMediator mediator)
            : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> Handle(TestObjectRequest request)
        {
            return await Execute(request, Ok);
        }
    }
}
