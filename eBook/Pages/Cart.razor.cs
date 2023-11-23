using eBook.Data;
using eBook.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.SqlClient;

namespace eBook.Pages
{
    public partial class Cart
    {
        private List<Author> authors = new List<Author>();
        private List<StockBalance> stockbalance = new List<StockBalance>();

        protected override async Task OnInitializedAsync()
        {
            authors = await dbcontext.Authors.ToListAsync();
            stockbalance = await dbcontext.StockBalances.ToListAsync();
        }
        private void RemoveFromCart(Book book)
        {
            Program.cart.RemoveFromCart(book);
        }


        private void ClearCart()
        {
            Program.cart.ClearCart();
            Navigation.NavigateTo("/Cart");
        }

        private void Login()
        {
            Navigation.NavigateTo("/Login");
        }

        private async Task Checkout()
        {
            var books = Program.cart.GetCartBooks();
            if (Program.cart != null)
            {
                CreateOrder();
                await Task.Delay(7000);
                Navigation.NavigateTo("/Checkout");
            }
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

        public async Task CreateOrder()
        {
            //Order
            decimal? sum = 0;
            foreach (var book in Program.cart.GetCartBooks())
            {
                sum += book.Price;
            }

            Order newOrder = new Order();
            newOrder.CustomerId = Program.CurrentUser.CustomerId;
            newOrder.PaymentAmount = sum;
            newOrder.PaymentMethod = "Klarna";

            dbcontext.Orders.Add(newOrder);
            await dbcontext.SaveChangesAsync();

            //Order details
            foreach(var book in Program.cart.GetCartBooks())
            {
                OrderDetail newOrderDetail = new OrderDetail();
                newOrderDetail.OrderId = newOrder.OrderId;
                newOrderDetail.Isbn13 = book.Isbn13;

                dbcontext.OrderDetails.Add(newOrderDetail);
                await dbcontext.SaveChangesAsync();
            }
        }
       


    }
}
