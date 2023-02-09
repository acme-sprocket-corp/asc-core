using System.ComponentModel.DataAnnotations;

namespace Core.Tests.Unit.API.Common.ObjectValidation
{
    public class TestObjectVerification
    {
        [Required]
        public string Value { get; set; } = string.Empty;
    }
}
