using Microsoft.AspNetCore.Mvc;
using ReviewsSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ReviewsSite.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly ITagRepository tagsRepo;
        private readonly ITagLinker tagLinker;

        public TagsController(ITagRepository tagsRepo, ITagLinker tagLinker)
        {
            this.tagsRepo = tagsRepo;
            this.tagLinker = tagLinker;
        }

        [HttpGet("{reviewId}")]
        public IEnumerable<Tag> Get(int reviewId)
        {
            return tagsRepo.GetTagsForReviewId(reviewId);
        }

        [HttpPost]
        public Tag Post([FromBody]Tag tag, int reviewId)
        {
            return tagLinker.LinkToReview(tag.Text, reviewId);
        }
    }
}
