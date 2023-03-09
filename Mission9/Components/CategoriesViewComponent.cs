using Microsoft.AspNetCore.Mvc;
using Mission9.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission9.Components
{
    public class CategoriesViewComponent : ViewComponent
    {
        private IMission9Repository repo { get; set; }
        public CategoriesViewComponent (IMission9Repository temp)
        {
            repo = temp;
        }
        //Creates view bag for the categories
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["bookCategory"];

            var categories = repo.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);

            return View(categories);
        }
    }
}
