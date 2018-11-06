using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReviewsSite.Models;

namespace ReviewsSite
{
    public class TagLinker : ITagLinker
    {
        private ITagRepository tagsRepo;
        private IReviewTagRepository reviewTagRepo;

        public TagLinker(ITagRepository tagsRepo, IReviewTagRepository reviewTagRepo)
        {
            this.tagsRepo = tagsRepo;
            this.reviewTagRepo = reviewTagRepo;
        }

        public Tag LinkToReview(string tagText, int reviewId)
        {
            var tag = FindOrCreateTag(tagText);
            LinkReviewToTag(reviewId, tag);
            return tag;
        }

        private void LinkReviewToTag(int reviewId, Tag tag)
        {
            reviewTagRepo.Create(new ReviewTag()
            {
                ReviewId = reviewId,
                TagId = tag.Id
            });
        }

        private Tag FindOrCreateTag(string text)
        {
            var tag = tagsRepo.FindByText(text);
            if (tag == null)
            {
                tag = new Tag() { Text = text };
                tagsRepo.Create(tag);
            }

            return tag;
        }
    }
}
