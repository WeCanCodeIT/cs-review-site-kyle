using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReviewsSite.Models;

namespace ReviewsSite
{
    public interface IReviewTagRepository
    {
        void Create(ReviewTag reviewTag);
    }
}
