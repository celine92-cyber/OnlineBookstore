using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookstore.Models
{
    public class Cart
    {
        public List<CartLine> Lines { get; set; } = new List<CartLine>();

        public void AddItem (Book book, int quantity)
        {
            CartLine line = Lines
                .Where(p => p.Book.BookId == book.BookId)
                .FirstOrDefault();

            if(line == null)
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

        public void RemoveLine(Book book) =>
            Lines.RemoveAll(x => x.Book.BookId == book.BookId);

        public void Clear() => Lines.Clear();

        public decimal ComputeTotalSum() => (decimal)Lines.Sum(e => e.Book.Price * e.Quantity);


        public class CartLine
        {
            public int CartLineID { get; set; }
            public Book Book { get; set; }
            public int Quantity { get; set; }

        }
    }
}
