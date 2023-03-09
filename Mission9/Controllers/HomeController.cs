using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mission9.Models;
using Mission9.Models.ViewModels;

namespace Mission9.Controllers
{
    public class HomeController : Controller
    {
        private IMission9Repository repo;
        public HomeController(IMission9Repository temp)
        {
            repo = temp;
        }
        public IActionResult Index(string bookCategory, int pageNum = 1)
        {
            int pageSize = 10;

            var x = new BooksViewModel
            {
                //creates different pages for the books
                Books = repo.Books
                .Where(p => p.Category == bookCategory || bookCategory == null)
                .OrderBy(p => p.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),
                
                PageInfo = new PageInfo
                {
                    TotalNumBooks = (bookCategory == null ? repo.Books.Count() : repo.Books.Where(x => x.Category == bookCategory).Count()),
                    BooksPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };
            return View(x);
        }
    }
}
