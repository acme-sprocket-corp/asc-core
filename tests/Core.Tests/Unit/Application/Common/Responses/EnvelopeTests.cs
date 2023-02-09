using Core.Application.Common.Responses;

namespace Core.Tests.Unit.Application.Common.Responses
{
    [TestClass]
    public class EnvelopeTests
    {
        [TestMethod]
        public void Success_ReturnsCorrectProperties()
        {
            const string response = "response";

            var envelope = Envelope<string>.Success(response);

            Assert.AreEqual(response, envelope.Response);
            Assert.AreEqual(Status.Success, envelope.Status);
            Assert.IsTrue(envelope.IsSuccess);
        }

        [TestMethod]
        public void Failure_ReturnsCorrectProperties()
        {
            const Status error = Status.ValidationError;

            var envelope = Envelope<string>.Failure(error);

            Assert.IsNull(envelope.Response);
            Assert.AreEqual(error, envelope.Status);
            Assert.IsFalse(envelope.IsSuccess);
        }
    }
}
