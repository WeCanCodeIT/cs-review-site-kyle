using ReviewsSite.Models;
using System.Collections.Generic;

namespace ReviewsSite
{
    public interface IReviewRepository
    {
        List<Review> GetAll();
    }
}
