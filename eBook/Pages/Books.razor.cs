using eBook.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace eBook.Pages
{
    public partial class Books
    {
        
        private List<Book> books = new List<Book>();
        private List<Store> stores = new List<Store>();
        private List<StockBalance> stockbalance = new List<StockBalance>();
        private List<Author> authors = new List<Author>();
        public int quantityOfPurchase = 1;

        protected override async Task OnInitializedAsync()
        {
            books = await dbcontext.Books.ToListAsync();
            stores = await dbcontext.Stores.ToListAsync();
            stockbalance = await dbcontext.StockBalances.ToListAsync();
            authors = await dbcontext.Authors.ToListAsync();
        }

        public async void UpdateChoosenStore(Store selectedStore)
        {
            Program.cart.ClearCart();
            Program.choosenStore = selectedStore;
            Navigation.NavigateTo("/Books");
        }

        public string GetStoreQuantity(Book b)
        {
            int? quantity = null;

            for(int i = 0; i < stockbalance.Count; i++)
            {
                if (b.Isbn13 == stockbalance[i].Isbn13 && Program.choosenStore.StoreId == stockbalance[i].StoreId)
                {
                    quantity = stockbalance[i].Quantity;

                    break;
                }
            }
            string quantityString = quantity?.ToString() ?? "0";
            return quantityString;
        }

        public string GetAuthorName(int? authorId)
        {
            string authorName = null;

            for (int i = 0; i < authors.Count; i++)
            {
                if (authorId == authors[i].AuthorId)
                {
                    authorName = $"{authors[i].FirstName} {authors[i].LastName}";
                    break;
                }
            }
            return authorName;
        }

        public string GetBookCover(Book book)
        {
            string coverPath = null;

            if(book.BookCover != null || book.BookCover != "")
            {
                coverPath = book.BookCover;
            }
            else
            {
                coverPath = "Images/Covers/defaultbook.png";
            }


            return coverPath;
        }

        public void Purchase(Book selectedBook, int quantity)
        {
            if(quantity == null)
            {
                quantity = 1;
            }
            for(int i = quantity; i > 0; i--)
            {
                Program.cart.AddToCart(selectedBook);

            }
            Navigation.NavigateTo("/Books");
        }
    }
}
