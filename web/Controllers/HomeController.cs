using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using web.Models;
using web.Data.Concrete;
using web.Data.Abstract;

namespace web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View(new HomeViewModel
            {
                HomeCategories = _unitOfWork.Categories.GetHomeCategories(),
                MostHaveComment = _unitOfWork.Posts.MostHaveComment(8)
            });
        }

        public IActionResult Category()
        {
            return View(_unitOfWork.Categories.GetAll());
        }

        public IActionResult LastAdded()
        {
            return View(_unitOfWork.Posts.LastAdded(20));
        }
        public IActionResult Popular()
        {
            return View(_unitOfWork.Categories.PopularCategories(20));
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
