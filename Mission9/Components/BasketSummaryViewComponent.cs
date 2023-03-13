using Microsoft.AspNetCore.Mvc;
using Mission9.Models;
namespace Mission9.Components
{
    public class BasketSummaryViewComponent : ViewComponent
    {
        private Basket basket;
        public BasketSummaryViewComponent(Basket basketService)
        {
            basket = basketService;
        }
        //Don't remember what this does tbh
        public IViewComponentResult Invoke()
        {
            return View(basket);
        }
    }
}