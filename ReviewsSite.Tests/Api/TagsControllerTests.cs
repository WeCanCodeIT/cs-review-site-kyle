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
        private IReviewTagRepository reviewTagRepo;
        private TagsController underTest;

        public TagsControllerTests()
        {
            tagsRepo = Substitute.For<ITagRepository>();
            reviewTagRepo = Substitute.For<IReviewTagRepository>();
            underTest = new TagsController(tagsRepo, reviewTagRepo);
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
       public void Post_Create_A_Tag()
        {
            var tag = new Tag();
            int reviewId = 42;

            underTest.Post(tag, reviewId);

            tagsRepo.Received().Create(tag); 
        }

        [Fact]
        public void Post_Associates_Tag_With_ReviewTag()
        {
            int reviewId = 42;
            var tag = new Tag() { Id = 43 };

            underTest.Post(tag, reviewId);

            reviewTagRepo.Received().Create(
                Arg.Is<ReviewTag>(rt => rt.ReviewId == reviewId && rt.TagId == tag.Id)
            );
        }

        [Fact]
        public void Post_Returns_Saved_Tag()
        {
            int reviewId = 42;
            var tag = new Tag() { Id = 43 };

            var result = underTest.Post(tag, reviewId);

            Assert.Same(tag, result);
        }
    }
}
