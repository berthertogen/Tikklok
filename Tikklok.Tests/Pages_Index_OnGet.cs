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
            var tiks = new Mock<ITiks>();
            var page = new IndexModel(tiks.Object);
            page.UserId = "ERTOGB";

            // Act
            page.OnGet();

            // Assert
            tiks.Verify(r => r.Get("ERTOGB"));
        }
        [Fact]
        public void ShouldNotGetWithoutUserId()
        {
            // Arrange
            var tiks = new Mock<ITiks>();
            var page = new IndexModel(tiks.Object);
            page.UserId = null;

            // Act
            page.OnGet();

            // Assert
            tiks.VerifyNoOtherCalls();
        }
    }
}
