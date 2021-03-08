using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineBookStore.Infrastructure;
using OnlineBookStore.Models;

namespace OnlineBookStore.Pages
{
    public class PurchaseModel : PageModel
    {
        private IBookRepository repository;

        //Constructor
        public PurchaseModel (IBookRepository repo)
        {
            repository = repo;
        }

        //Properties
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }

        //Methods
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();

        }

        public IActionResult OnPost (long bookId, string returnUrl, string actionToPerform)
        {
            Book book = repository.Books.FirstOrDefault(b => b.BookId == bookId);

            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();

            if (actionToPerform == "addItem")
            {
                Cart.AddItem(book, 1);
            }
            else
            {
                Cart.RemoveLine(book);
            }
            

            HttpContext.Session.SetJson("cart", Cart);

            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}
