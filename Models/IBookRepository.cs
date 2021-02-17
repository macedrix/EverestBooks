using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookStore.Models
{
    public interface IBookRepository
    {
        //Create an IQueryable of Book objects called Books
        IQueryable<Book> Books { get; }
    }
}
