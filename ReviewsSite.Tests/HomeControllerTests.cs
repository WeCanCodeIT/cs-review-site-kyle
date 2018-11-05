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
        private IReviewRepository reviewRepo;
        private HomeController underTest;

        public HomeControllerTests()
        {
            reviewRepo = Substitute.For<IReviewRepository>();
            underTest = new HomeController(reviewRepo);
        }

        [Fact]
        public void Index_Returns_A_View()
        {
            var result = underTest.Index();

            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Index_Passes_All_Reviews_To_View()
        {
            var expectedReviews = new List<Review>();
            reviewRepo.GetAll().Returns(expectedReviews);

            var result = underTest.Index();

            Assert.Equal(expectedReviews, result.Model);
        }

        [Fact]
        public void Details_Returns_A_View()
        {
            var result = underTest.Details(1);

            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Details_Passes_Review_To_View()
        {
            var expectedReview = new Review();
            reviewRepo.GetById(1).Returns(expectedReview);

            var result = underTest.Details(1);

            Assert.Equal(expectedReview, result.Model);
        }
    }
}
