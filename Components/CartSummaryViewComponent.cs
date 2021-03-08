using Microsoft.AspNetCore.Mvc;
using OnlineBookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookStore.Components
{
    //Component that we can input later as a summary of the cart
    public class CartSummaryViewComponent : ViewComponent
    {
        private Cart cart;

        public CartSummaryViewComponent(Cart cartService)
        {
            cart = cartService;
        }

        public IViewComponentResult Invoke()
        {
            return View(cart);
        }
    }
}
