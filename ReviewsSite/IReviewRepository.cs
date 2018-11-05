using ReviewsSite.Models;
using System.Collections.Generic;

namespace ReviewsSite
{
    public interface IReviewRepository
    {
        IEnumerable<Review> GetAll();
        Review GetById(int id);
    }
}
