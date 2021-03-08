using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookStore.Models
{
    public class Cart
    {
        //Create list of cart lines
        public List<CartLine> Lines { get; set; } = new List<CartLine>();

        public IEnumerable<CartLine> LinesEnumerable => Lines;

        //Method for adding an item
        public void AddItem (Book book, int quantity)
        {
            //Go to where the book matches the book id sent in
            CartLine line = Lines
                .Where(b => b.Book.BookId == book.BookId)
                .FirstOrDefault();

            //If the book is already in the card, just add to the quantity
            //Or create a new line
            if (line == null)
            {
                Lines.Add(new CartLine
                {
                    Book = book,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        //Remove a book from the cart
        public void RemoveLine(Book book) =>
            Lines.RemoveAll(x => x.Book.BookId == book.BookId);

        //Clear the cart
        public void Clear() => Lines.Clear();

        //Calculate the cart total
        public decimal ComputeTotalSum() => Lines.Sum(e => (decimal)e.Book.Price * e.Quantity);

        //Cart line class
        public class CartLine
        {
            public int CartLineId { get; set; }
            public Book Book { get; set; }
            public int Quantity { get; set; }
        }
    }
}