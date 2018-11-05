using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewsSite.Models
{
    public class ReviewTag
    {
        public int Id { get; set; }
        public int ReviewId { get; set; }
        public virtual Review Review { get; set; }
        public int TagId { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
