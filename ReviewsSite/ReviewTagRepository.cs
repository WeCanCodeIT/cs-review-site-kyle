using Microsoft.EntityFrameworkCore;
using ReviewsSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewsSite
{
    public class ReviewTagRepository : Repository<ReviewTag>, IReviewTagRepository
    {
        public ReviewTagRepository(MoviesContext db) : base(db)
        { }
    }
}
