using eBook.Data;
using eBook.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity.Core.Common.CommandTrees;

namespace eBook.Pages
{
    public partial class User
    {
        private List<Order> orders = new List<Order>();
        private List<OrderDetail> orderDetails = new List<OrderDetail>();
        private List<Book> books = new List<Book>();
        private List<Author> authors = new List<Author>();

        protected override async Task OnInitializedAsync()
        {

            if (Program.CurrentUser != null)
            {
                if(Program.CurrentUser.CustomerId != 7)
                {
                    using (var context = new StoreDBContext())
                    {
                        orders = await context.Orders.ToListAsync();
                    }

                    using (var context = new StoreDBContext())
                    {
                        orderDetails = await context.OrderDetails.ToListAsync();
                    }

                    using (var context = new StoreDBContext())
                    {
                        books = await dbcontext.Books.ToListAsync();
                    }

                    using (var context = new StoreDBContext())
                    {
                        authors = await dbcontext.Authors.ToListAsync();
                    }
                }
            }
            //orders = await dbcontext.Orders.ToListAsync();
            //orderDetails = await dbcontext.OrderDetails.ToListAsync();
            //books = await dbcontext.Books.ToListAsync();
            //authors = await dbcontext.Authors.ToListAsync();
        }
        public void LogOut()
        {
            Program.CurrentUser = null;
            Program.cart.ClearCart();
            Navigation.NavigateTo("/");
        }

        private async Task UpdateUser()
        {
            dbcontext.Customers.Update(Program.CurrentUser);
            await dbcontext.SaveChangesAsync();
        }

        private Book GetBook(string isbn)
        {
            Book book = null;

            foreach(var b in books)
            {
                if(b.Isbn13 == isbn)
                {
                    book = b; 
                    break;
                }
            }

            return book;
        }

        private Author GetAuthor(int? authorId)
        {
            Author author = null;

            foreach(var a in authors)
            {
                if(a.AuthorId == authorId)
                {
                    author = a;
                    break;
                }
            }

            return author;
        }

        

    }
}
