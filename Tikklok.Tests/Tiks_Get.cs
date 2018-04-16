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
    public class Tiks_Get
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
            var tikker = new Tiks(repo.Object, () => new DateTime(2018, 1, 1, 8, 0, 0));

            // Act
            var result = tikker.Get("ERTOGB");

            // Assert
            Assert.Equal(tiklines, result.ToList());
        }
    }
}
