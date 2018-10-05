using System;

namespace ReviewsSite.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string ReviewCategory { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
    }
}
