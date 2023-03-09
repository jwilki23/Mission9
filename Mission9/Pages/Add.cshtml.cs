using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mission9.Infrastructures;
using Mission9.Models;

namespace Mission9.Pages
{
    public class AddModel : PageModel
    {
        // Model to allow a user to add a book to their cart. Includes getter and setter for the repository, initializes the repository, creates an instance of a basket, gets and sets the return url, 
        // has functionality on get to populate the page with data related to the basket passed, and when it posts the data, it takes them back to the url they were just on. 
        private IMission9Repository repo { get; set; }
        public AddModel (IMission9Repository temp)
        {
            repo = temp;
        }
        public Basket basket { get; set; }
        public string ReturnUrl { get; set; }

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            basket = HttpContext.Session.GetJson<Basket>("basket") ?? new Basket();
        }

        public IActionResult OnPost(int bookId, string returnUrl)
        {
            Book b = repo.Books.FirstOrDefault(x => x.BookId == bookId);
            basket = HttpContext.Session.GetJson<Basket>("basket") ?? new Basket();
            basket.AddItem(b, 1);

            HttpContext.Session.SetJson("basket", basket);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
    }
}
