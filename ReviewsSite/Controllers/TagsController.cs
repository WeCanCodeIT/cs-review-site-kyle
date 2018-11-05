using System;
using Microsoft.AspNetCore.Mvc;
using ReviewsSite.Models;

namespace ReviewsSite.Controllers
{
    public class TagsController : Controller
    {
        private readonly ITagRepository tagRepository;

        public TagsController(ITagRepository tagRepository)
        {
            this.tagRepository = tagRepository;
        }

        public ViewResult Details(int id)
        {
            var model = tagRepository.GetById(id);
            return View(model);
        }
    }
}
