using Microsoft.EntityFrameworkCore;
using ReviewsSite.Models;
using System.Collections.Generic;
using System.Linq;

namespace ReviewsSite
{
    public class TagRepository : Repository<Tag>, ITagRepository
    {
        public TagRepository(MoviesContext db) : base(db)
        { }

        public Tag FindByText(string text)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Tag> GetTagsForReviewId(int reviewId)
        {
            var result = from tag in GetAll()
                         from reviewTag in tag.ReviewTags
                         where reviewTag.ReviewId == reviewId
                         select tag;
            return result;
        }
    }
}
