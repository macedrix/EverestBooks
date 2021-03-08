using OnlineBookStore.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookStore.Models.ViewModels
{
    public class BookListViewModel
    {
        //Adds the paging info into the model being sent to the index page
        public IEnumerable<Book> Books { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }

        //Include a cart in the ViewModel
        public Cart Cart { get; set; }
    }
}
