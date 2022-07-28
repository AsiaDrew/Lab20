using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        MovieDAL movieDAL = new MovieDAL();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MovieSearch()
        {
            return View();
        }

        [HttpPost]
        public IActionResult MovieSearch(string title)
        {
            MovieModel result = movieDAL.GetMovie(title);
            return View(result);
        }

        [HttpGet]
        public IActionResult MovieNight()
        {
            return View();
        }

        [HttpPost]
        public IActionResult MovieNight(string title1, string title2, string title3)
        {
            List<MovieModel> result = new List<MovieModel>
            {
                movieDAL.GetMovie(title1),
                movieDAL.GetMovie(title2),
                movieDAL.GetMovie(title3)
            };
            return View(result);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}