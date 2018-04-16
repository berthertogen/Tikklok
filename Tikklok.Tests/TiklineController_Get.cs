using Microsoft.AspNetCore.Mvc;
using Moq;
using Tikklok.Business;
using Tikklok.Controllers;
using Xunit;

namespace Tikklok.Tests
{
    public class TiklineController_Get
    {
        [Fact]
        public void ShouldGetWithUserId()
        {
            // Arrange
            var tikked = new Mock<ITikked>();
            var controller = new TiklinesController(tikked.Object);

            // Act
            var result = controller.Get("ERTOGB");

            // Assert
            tikked.Verify(r => r.Tiks("ERTOGB"));
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void ShouldNotGetWithoutUserId()
        {
            // Arrange
            var tikked = new Mock<ITikked>();
            var controller = new TiklinesController(tikked.Object);

            // Act
            var result = controller.Get(null);

            // Assert
            tikked.VerifyNoOtherCalls();
            Assert.IsType<BadRequestResult>(result);
        }
    }
}
