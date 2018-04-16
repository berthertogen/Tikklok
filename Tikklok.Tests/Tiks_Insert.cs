using Moq;
using System;
using System.Collections.Generic;
using Tikklok.Business;
using Tikklok.Data;
using Tikklok.Models;
using Xunit;

namespace Tikklok.Tests
{
    public class Tiks_Insert
    {
        [Fact]
        public void Should_Add()
        {
            // Arrange
            var repo = new Mock<ITiklineDb>();
            var tikker = new Tiks(repo.Object, () => new DateTime(2018,1,1,8,0,0));

            // Act
            tikker.Insert("ERTOGB", TikAction.Start);

            // Assert
            var expected = new Tikline {
                Time = new DateTime(2018, 1, 1, 8, 0, 0),
                Action = TikAction.Start,
                UserId = "ERTOGB"
            };
            repo.Verify(r => r.Insert(expected));
        }

        [Fact]
        public void Should_NotAddWhenLastActionIsSame()
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
            tikker.Insert("ERTOGB", TikAction.Start);

            // Assert
            repo.Verify(r => r.Get("ERTOGB"));
            repo.VerifyNoOtherCalls();
        }
    }
}
