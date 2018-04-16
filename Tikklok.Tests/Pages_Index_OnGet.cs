using Moq;
using Tikklok.Business;
using Xunit;

namespace Tikklok.Tests
{
    public class Pages_Index_OnGet
    {
        [Fact]
        public void ShouldGetWithUserId()
        {
            // Arrange
            var tikked = new Mock<ITikked>();
            var tikker = new Mock<ITikker>();
            var page = new IndexModel(tikked.Object, tikker.Object);
            page.UserId = "ERTOGB";

            // Act
            page.OnGet();

            // Assert
            tikked.Verify(r => r.Tiks("ERTOGB"));
        }
        [Fact]
        public void ShouldNotGetWithoutUserId()
        {
            // Arrange
            var tikked = new Mock<ITikked>();
            var tikker = new Mock<ITikker>();
            var page = new IndexModel(tikked.Object, tikker.Object);
            page.UserId = null;

            // Act
            page.OnGet();

            // Assert
            tikked.VerifyNoOtherCalls();
        }
    }
}
