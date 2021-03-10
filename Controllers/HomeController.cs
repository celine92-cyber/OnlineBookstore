using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineBookstore.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using OnlineBookstore.Models.ViewModels;

namespace OnlineBookstore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private IOnlineBookstoreRepository _repository;

        public int PageSize = 5;

        public HomeController(ILogger<HomeController> logger, IOnlineBookstoreRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public IActionResult Index(string category ,int pageNum = 1)
        {
            if (ModelState.IsValid)
            {

                return View(new BookListsViewModel
                    {
                            Books = _repository.Books
                                .Where(p => category == null || p.Category == category )// add filters
                                .OrderBy(p => p.BookId)
                                .Skip((pageNum - 1) * PageSize)
                                .Take(PageSize),
                            PagingInfo = new PagingInfo
                            {
                                CurrentPage = pageNum,
                                ItemsPerPage = PageSize,
                                TotalNumItems = category == null ? _repository.Books.Count() :
                                    _repository.Books.Where(x => x.Category ==category).Count() //these two lines help us print out only the existing pages for each category

                            },
                            Category = category

                    });
            }

            else
            {
                return View();
            }
            
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
