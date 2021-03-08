using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookStore.Models
{
    //Interface, not a class. Can't have objects from it, but can have classes inherit from it
    public interface IBookRepository
    {
        //Create an IQueryable of Book objects called Books
        IQueryable<Book> Books { get; }
    }
}
