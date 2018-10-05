using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using ReviewsSite.Controllers;
using ReviewsSite.Models;
using System.Collections.Generic;
using Xunit;

namespace ReviewsSite.Tests
{
    public class HomeControllerTests
    {
        [Fact]
        public void Index_Returns_A_View()
        {
            var reviewRepo = Substitute.For<IReviewRepository>();
            var underTest = new HomeController(reviewRepo);

            var result = underTest.Index();

            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Index_Passes_All_Reviews_To_View()
        {
            var expectedReviews = new List<Review>();
            var reviewRepo = Substitute.For<IReviewRepository>();
            reviewRepo.GetAll().Returns(expectedReviews);
            var underTest = new HomeController(reviewRepo);

            var result = underTest.Index();

            Assert.Equal(expectedReviews, result.Model);
        }
    }
}
