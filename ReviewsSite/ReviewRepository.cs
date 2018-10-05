using System;
using System.Collections.Generic;
using System.Linq;
using ReviewsSite.Models;

namespace ReviewsSite
{
    public class ReviewRepository : IReviewRepository
    {
        private Dictionary<int, Review> allReviews = new Dictionary<int, Review>()
        {
            { 1, new Review() {
                Id = 1,
                Title ="Spiderman",
                ImageUrl ="/images/spiderman.jpg",
                ReviewCategory ="Action",
                Content ="It was an ok movie, I guess.",
                Date = new DateTime(2010, 10, 10)
            } },
            { 2, new Review() {
                Id = 2,
                Title ="Batman",
                ImageUrl ="/images/batman.jpg",
                ReviewCategory ="Action",
                Content ="It was great-ish",
                Date = new DateTime(2009, 9, 9)
            } },
            { 3, new Review() {
                Id = 3,
                Title ="X-Men",
                ImageUrl ="/images/xmen.jpg",
                ReviewCategory ="Action",
                Content ="It was a awesome!",
                Date = new DateTime(2008, 8, 8)
            } },
        };

        public Review FindById(int id)
        {
            return allReviews[id];
        }

        public List<Review> GetAll()
        {
            return allReviews.Values.ToList();
        }
    }
}
