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

        public Tag LinkToReview(string text, int reviewId)
        {
            var tag = new Tag() { Text = text };
            var existingTag = tagsRepo.FindByText(tag.Text);
            if (existingTag == null)
            {
                tagsRepo.Create(tag);
            }
            reviewTagRepo.Create(new ReviewTag()
            {
                ReviewId = reviewId,
                TagId = tag.Id
            });
            return tag;
        }
    }
}
