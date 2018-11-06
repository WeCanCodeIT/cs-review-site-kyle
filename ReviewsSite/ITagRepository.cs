using ReviewsSite.Models;
using System.Collections.Generic;

namespace ReviewsSite
{
    public interface ITagRepository
    {
        IEnumerable<Tag> GetTagsForReviewId(int reviewId);
        void Create(Tag tag);
        Tag GetById(int tagId);
        Tag FindByText(string text);
    }
}
