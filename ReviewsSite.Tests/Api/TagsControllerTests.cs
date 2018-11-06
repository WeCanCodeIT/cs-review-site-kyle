using NSubstitute;
using ReviewsSite.Controllers.api;
using ReviewsSite.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ReviewsSite.Tests.Api
{
    public class TagsControllerTests
    {
        private ITagRepository tagsRepo;
        private ITagLinker tagLinker;
        private TagsController underTest;

        public TagsControllerTests()
        {
            tagsRepo = Substitute.For<ITagRepository>();
            tagLinker = Substitute.For<ITagLinker>();
            underTest = new TagsController(tagsRepo, tagLinker);
        }

        [Fact]
        public void Get_Returns_All_Tags_For_Review()
        {
            int reviewId = 42;
            var expectedTags = new List<Tag>();
            tagsRepo.GetTagsForReviewId(reviewId).Returns(expectedTags);

            var result = underTest.Get(reviewId);

            Assert.Same(expectedTags, result);
        }

        [Fact]
        public void Post_Links_Tag_To_Review()
        {
            var tag = new Tag() { Text = "Hello" };
            var reviewId = 42;

            underTest.Post(tag, reviewId);

            tagLinker.Received().LinkToReview(tag.Text, reviewId);
        }
    }
}
