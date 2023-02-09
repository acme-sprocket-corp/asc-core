using Core.Application.Common.CodeContracts;

namespace Core.Tests.Unit.Application.Common.CodeContracts
{
    [TestClass]
    public class ContractsTests
    {
        [TestMethod]
        public void MustNotBeNull_OnNullClass_ThrowsException()
        {
            Assert.ThrowsException<ArgumentNullException>(() => Contract.MustNotBeNull<string>(null));
        }

        [TestMethod]
        public void MustNotBeNull_OnInstance_DoesNotThrowException()
        {
            Contract.MustNotBeNull("myString");
        }
    }
}
