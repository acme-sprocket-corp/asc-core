using Core.Application.Common.Responses;

namespace Core.Tests.Unit.Application.Common.Responses
{
    [TestClass]
    public class EnvelopeTests
    {
        [TestMethod]
        public void Success_ReturnsCorrectProperties()
        {
            var response = new TestResponse();

            var envelope = Envelope<TestResponse>.Success(response);

            Assert.AreEqual(response, envelope.Response);
            Assert.AreEqual(Status.Success, envelope.Status);
        }

        [TestMethod]
        public void Failure_ReturnsCorrectProperties()
        {
            const Status error = Status.ValidationError;

            var envelope = Envelope<TestResponse>.Failure(error, string.Empty);

            Assert.IsNull(envelope.Response);
            Assert.AreEqual(error, envelope.Status);
        }
    }
}
