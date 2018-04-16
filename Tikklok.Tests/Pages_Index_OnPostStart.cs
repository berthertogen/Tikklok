using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Tikklok.Business;
using Tikklok.Models;
using Xunit;

namespace Tikklok.Tests
{
    public class Pages_Index_OnOnPostStart
    {
        [Fact]
        public void ShouldInWithUserId()
        {
            // Arrange
            var tikked = new Mock<ITikked>();
            var tikker = new Mock<ITikker>();
            var page = new IndexModel(tikked.Object, tikker.Object);
            page.UserId = "ERTOGB";
            var tiklines = new List<Tikline> {
                new Tikline{ UserId="ERTOGB", Time = new DateTime(2018,1,1,10,0,0), Action = TikAction.Stop},
                new Tikline { UserId = "ERTOGB", Time = new DateTime(2018, 1, 1, 8, 0, 0), Action = TikAction.Start},
            };
            tikked.Setup(r => r.Tiks("ERTOGB")).Returns(tiklines);

            // Act
            page.OnPostStart();

            // Assert
            tikker.Verify(r => r.Tik(page.UserId, TikAction.Start));
            Assert.Equal(tiklines, page.Tiklines);
        }

        [Fact]
        public void ShouldNotInWithoutUserId()
        {
            // Arrange
            var tikked = new Mock<ITikked>();
            var tikker = new Mock<ITikker>();
            var page = new IndexModel(tikked.Object, tikker.Object);
            page.UserId = null;

            // Act
            page.OnPostStart();

            // Assert
            tikked.VerifyNoOtherCalls();
            Assert.True(page.Tiklines.Count() == 0);
        }
    }
}
