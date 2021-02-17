using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookStore.Models
{
    public class EFBookRepository : IBookRepository
    {
        private BookStoreDBContext _context;

        //Constructor
        public EFBookRepository (BookStoreDBContext context)
        {
            _context = context;
        }

        //By using a IQueryable, we can query the database in order to display them
        public IQueryable<Book> Books => _context.Books;

    }
}
