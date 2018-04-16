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
            var tiks = new Mock<ITiks>();
            var page = new IndexModel(tiks.Object);
            page.UserId = "ERTOGB";
            var tiklines = new List<Tikline> {
                new Tikline{ UserId="ERTOGB", Time = new DateTime(2018,1,1,10,0,0), Action = TikAction.Stop},
                new Tikline { UserId = "ERTOGB", Time = new DateTime(2018, 1, 1, 8, 0, 0), Action = TikAction.Start},
            };
            tiks.Setup(r => r.Get("ERTOGB")).Returns(tiklines);

            // Act
            page.OnPostStart();

            // Assert
            tiks.Verify(r => r.Insert(page.UserId, TikAction.Start));
            Assert.Equal(tiklines, page.Tiklines);
        }

        [Fact]
        public void ShouldNotInWithoutUserId()
        {
            // Arrange
            var tiks = new Mock<ITiks>();
            var page = new IndexModel(tiks.Object);
            page.UserId = null;

            // Act
            page.OnPostStart();

            // Assert
            tiks.VerifyNoOtherCalls();
            Assert.True(page.Tiklines.Count() == 0);
        }
    }
}
