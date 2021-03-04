using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineBookStore.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using OnlineBookStore.Models.ViewModels;

namespace OnlineBookStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private IBookRepository _repository;

        //Define how many objects per page
        public int PageSize = 5;

        public HomeController(ILogger<HomeController> logger, IBookRepository repository)
        {
            _logger = logger;
            //Create the reponsitory
            _repository = repository;
        }

        public IActionResult Index(string category, int page = 1)
        {
            //Send in the repository with the book objects to be displayed
            return View(
             new BookListViewModel
             {
                 //Sort the books so that I get the ones for that page
                 Books = _repository.Books
                .Where(b => category == null || b.Category == category)
                .OrderBy(p => p.BookId)
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                ,
                 //Also send in paging info into the model
                 PagingInfo = new PagingInfo
                 {
                     //Only show number of pages that match the category searched
                     CurrentPage = page,
                     ItemsPerPage = PageSize,
                     TotalNumItems = category == null ? _repository.Books.Count() :
                     _repository.Books.Where(x => x.Category == category).Count()
                 },
                 CurrentCategory = category
             }) ;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
