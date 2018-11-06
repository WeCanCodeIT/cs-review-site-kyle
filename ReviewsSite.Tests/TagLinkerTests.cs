using NSubstitute;
using ReviewsSite.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ReviewsSite.Tests
{
    public class TagLinkerTests
    {
        private ITagRepository tagsRepo;
        private IReviewTagRepository reviewTagRepo;
        private TagLinker underTest;

        public TagLinkerTests()
        {
            tagsRepo = Substitute.For<ITagRepository>();
            reviewTagRepo = Substitute.For<IReviewTagRepository>();
            underTest = new TagLinker(tagsRepo, reviewTagRepo);
        }

        [Fact]
        public void LinkToReview_Creates_A_Tag()
        {
            var tagText = "foo";
            int reviewId = 42;

            underTest.LinkToReview(tagText, reviewId);

            tagsRepo.Received().Create(Arg.Is<Tag>(t => t.Text == tagText));
        }

        [Fact]
        public void LinkToReview_Associates_New_Tag_With_ReviewTag()
        {
            int reviewId = 42;
            var tagText = "Foo";
            const int expectedTagId = 490;
            tagsRepo.Create(Arg.Do<Tag>(t => t.Id = expectedTagId));

            underTest.LinkToReview(tagText, reviewId);

            reviewTagRepo.Received().Create(
                Arg.Is<ReviewTag>(rt => rt.ReviewId == reviewId && rt.TagId == expectedTagId)
            );
        }

        [Fact]
        public void LinkToReview_Returns_Saved_Tag()
        {
            int reviewId = 42;
            var tagText = "Foo";

            var result = underTest.LinkToReview(tagText, reviewId);

            Assert.Same(tagText, result.Text);
        }

        [Fact]
        public void LinkToReview_Does_Not_Create_Duplicate_Tags()
        {
            int reviewId = 42;
            var tagText = "Foo";
            var existingTag = new Tag() { Id = 1, Text = tagText };
            tagsRepo.FindByText(tagText).Returns(existingTag);

            var result = underTest.LinkToReview(tagText, reviewId);

            tagsRepo.DidNotReceiveWithAnyArgs().Create(null);
        }

        [Fact]
        public void LinkToReview_Associates_Existing_Tag_Id_To_Review()
        {
            var existingTag = new Tag() { Id = 42, Text = "Foo" };
            tagsRepo.FindByText(existingTag.Text).Returns(existingTag);

            underTest.LinkToReview(existingTag.Text, 14);

            reviewTagRepo.Received().Create(Arg.Is<ReviewTag>(rt => rt.TagId == existingTag.Id));
        }
    }
}
