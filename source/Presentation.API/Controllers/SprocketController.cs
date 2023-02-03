using Microsoft.AspNetCore.Mvc;

namespace Presentation.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public class SprocketController : ControllerBase
    {
        [HttpGet("", Name = "GetAllSprockets")]
        [ProducesResponseType(typeof(IEnumerable<string>), StatusCodes.Status200OK)]
        public Task<IActionResult> GetAllSprockets()
        {
            var result = Ok(new List<string> { "one", "two", "three" });

            return Task.FromResult(result as IActionResult);
        }
    }
}
