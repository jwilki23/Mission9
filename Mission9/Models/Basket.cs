using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission9.Models
{
    // creates a basket case that is used to take the data from the book selected and create these new variables that are used in the add view. 
    public class Basket
    {
        public List<BasketLineItem> Items { get; set; } = new List<BasketLineItem>();
        // method to add an item to the basket
        public virtual void AddItem (Book book, int qty)
        {
            BasketLineItem Line = Items
                .Where(b => b.Book.BookId == book.BookId)
                .FirstOrDefault();

            if (Line == null)
                Items.Add(new BasketLineItem
                {
                    Book = book,
                    Quantity = qty
                });
            else
            {
                Line.Quantity += qty;
            }
        }
        //Enables a user to eliminate books from cart.
        public virtual void RemoveItem(Book book)
        {
            Items.RemoveAll(x => x.Book.BookId == book.BookId);
        }
        //Clears entire cart
        public virtual void ClearBasket()
        {
            Items.Clear();
        }
        //method to calculate total cost that will be used in the table. 

        public double CalculateTotal()
        {
            double sum = (double)Items.Sum(x => x.Quantity * x.Book.Price);

            return sum;
        }

    }



    public class BasketLineItem
    {
        [Key]
        public int LineID { get; set; }
        public Book Book { get; set; }
        public int Quantity { get; set; }

    }
}
