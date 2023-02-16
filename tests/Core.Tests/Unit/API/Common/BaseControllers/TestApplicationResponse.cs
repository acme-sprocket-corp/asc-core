using Core.Application.Common.Responses;

namespace Core.Tests.Unit.API.Common.BaseControllers
{
    public class TestApplicationResponse : ApplicationResponse
    {
        public string Value { get; set; } = string.Empty;
    }
}
