using System.ComponentModel.DataAnnotations;
using MediatR;

namespace Core.Tests.Unit.API.Common.BaseControllers
{
    public class TestObjectRequest : IRequest<TestResponse>
    {
        [Required(AllowEmptyStrings = false)]
        public string TestField { get; set; } = string.Empty;

        public static TestObjectRequest Valid()
        {
            return new TestObjectRequest { TestField = "valid" };
        }

        public static TestObjectRequest InValid()
        {
            return new TestObjectRequest { TestField = string.Empty };
        }
    }
}
