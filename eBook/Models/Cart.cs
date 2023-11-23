using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace eBook.Models
{
    public class Cart
    {
        //public Order Order { get; private set; } = new Order(); 
        private List<Book> _cart = new List<Book>();

        public void AddToCart(Book book)
        {
            _cart.Add(book);
        }

        public void RemoveFromCart(Book book)
        {
            _cart.Remove(book);
        }

        public List<Book> GetCartBooks()
        {
            return _cart;
        }

        public string GetCartCount()
        {
            string cartCount = _cart.Count.ToString();
            return cartCount;
        }

        public decimal? GetTotal()
        {
            decimal? total = 0;

            foreach (var book in _cart)
            {
                total = total + book.Price;
            }

            return total;
        }

        public void ClearCart()
        {
            _cart.Clear();
        }
    }
}
