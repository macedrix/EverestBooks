using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookStore.Models
{
    public class BookStoreDBContext : DbContext
    {
        //Leave this for now, we will do something with it later
        public BookStoreDBContext (DbContextOptions<BookStoreDBContext> options) : base (options)
        {

        }

        //Create a database set made of Book objects
        public DbSet<Book> Books { get; set; }
    }
}
