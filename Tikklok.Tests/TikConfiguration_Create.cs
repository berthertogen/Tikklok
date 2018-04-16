using Tikklok.Sync.Business;
using Xunit;

namespace Tikklok.Tests
{
    public class TikConfiguration_Create
    {
        [Fact]
        public void Should_FillProperties()
        {
            // Arrange

            // Act
            var result = TikConfiguration.Create("path=\\test\trst\rettrd", "padder=s", "endpoint=http://test.com/api/tiklines/");

            // Assert
            Assert.Equal('s', result.Padder);
            Assert.Equal("\\test\trst\rettrd", result.Path);
            Assert.Equal("http://test.com/api/tiklines/", result.Endpoint);
        }

        [Fact]
        public void Should_FillPropertiesRegardlessOfOrder()
        {
            // Arrange

            // Act
            var result = TikConfiguration.Create("padder=s", "endpoint=http://test.com/api/tiklines/", "path=\\test\trst\rettrd");

            // Assert
            Assert.Equal('s', result.Padder);
            Assert.Equal("\\test\trst\rettrd", result.Path);
            Assert.Equal("http://test.com/api/tiklines/", result.Endpoint);
        }

        [Fact]
        public void Should_FillPropertiesRegardlessCasing()
        {
            // Arrange

            // Act
            var result = TikConfiguration.Create("PaDDeR=s", "endPOINT=http://test.com/api/tiklines/", "pAtH=\\test\trst\rettrd");

            // Assert
            Assert.Equal('s', result.Padder);
            Assert.Equal("\\test\trst\rettrd", result.Path);
            Assert.Equal("http://test.com/api/tiklines/", result.Endpoint);
        }

        [Fact]
        public void Should_HandleNoArguments()
        {
            // Arrange

            // Act
            var result = TikConfiguration.Create();

            // Assert
            Assert.Equal('_', result.Padder);
            Assert.Null(result.Path);
            Assert.Null(result.Endpoint);
        }
    }
}
