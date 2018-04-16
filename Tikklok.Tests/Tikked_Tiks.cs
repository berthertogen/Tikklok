using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tikklok.Business;
using Tikklok.Data;
using Tikklok.Models;
using Xunit;

namespace Tikklok.Tests
{
    public class Tikked_Tiks
    {
        [Fact]
        public void Should_Get()
        {
            // Arrange
            var repo = new Mock<ITiklineDb>();
            var tiklines = new List<Tikline>
            {
                new Tikline{ UserId = "ERTOGB", Time = new DateTime(2018,1,1), Action = TikAction.Start }
            };
            repo.Setup(r => r.Get("ERTOGB")).Returns(tiklines);
            var tikker = new Tikked(repo.Object);

            // Act
            var result = tikker.Tiks("ERTOGB");

            // Assert
            Assert.Equal(tiklines, result.ToList());
        }
    }
}
