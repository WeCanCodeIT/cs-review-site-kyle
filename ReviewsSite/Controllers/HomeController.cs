using Microsoft.AspNetCore.Mvc;

namespace ReviewsSite.Controllers
{
    public class HomeController : Controller
    {
        private IReviewRepository reviewRepo;

        public HomeController(IReviewRepository reviewRepo)
        {
            this.reviewRepo = reviewRepo;
        }

        public ViewResult Index()
        {
            var allReviews = reviewRepo.GetAll();
            return View(allReviews);
        }

        public ViewResult Details(int id)
        {
            var review = reviewRepo.FindById(id);
            return View(review);
        }
    }
}
