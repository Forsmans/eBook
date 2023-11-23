using eBook.Data;
using eBook.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;


namespace eBook.Pages
{
    public partial class Admin
    {
        private List<Book> books = new List<Book>();
        private Book newBook = new Book();
        private Book updateBook;

        private List<Author> authors = new List<Author>();
        private Author newAuthor = new Author();
        private string selectedAuthorId;
        private Author updateAuthor;
        private bool IsAuthorSelected(int authorId) => updateBook.AuthorId == authorId;

        protected override async Task OnInitializedAsync()
        {
            using (var context = new StoreDBContext())
            {
                books = await dbcontext.Books.ToListAsync();
            }

            using (var context = new StoreDBContext())
            {
                authors = await dbcontext.Authors.ToListAsync();
            }


            //authors = await dbcontext.Authors.ToListAsync();
            //books = await dbcontext.Books.ToListAsync();
        }
        public void LogOut()
        {
            Navigation.NavigateTo("/");
            Program.CurrentUser = null;
            Program.cart.ClearCart();
        }
        private async Task AddBook()
        {
            dbcontext.Books.Add(newBook);
            await dbcontext.SaveChangesAsync();
            books = await dbcontext.Books.ToListAsync();
            Navigation.NavigateTo("/Admin");
        }

        public void UpdateSelectedBook(ChangeEventArgs e)
        {
            if (e.Value is string[] values && values.Length > 0)
            {
                var selectedBookISBN = values[0];
                updateBook = books.FirstOrDefault(b => b.Isbn13 == selectedBookISBN);
            }
            else
            {
                // Handle the case where the array is empty or not in the expected format.
            }
        }

        private async Task UpdateBook()
        {
            dbcontext.Books.Update(updateBook);
            await dbcontext.SaveChangesAsync();
            Navigation.NavigateTo("/Admin");
        }

        private async Task DeleteBook()
        {
            dbcontext.Books.Remove(updateBook);
            await dbcontext.SaveChangesAsync();
            books = await dbcontext.Books.ToListAsync();
            Navigation.NavigateTo("/Admin");
        }


        private async Task AddAuthor()
        {
            dbcontext.Authors.Add(newAuthor);
            await dbcontext.SaveChangesAsync();
            
        }

        public void UpdateSelectedAuthor(ChangeEventArgs e)
        {
            if (e.Value is string[] values && values.Length > 0)
            {
                selectedAuthorId = values[0];
                updateAuthor = authors.FirstOrDefault(a => a.AuthorId.ToString() == selectedAuthorId);
            }
            else
            {
            }
        }

        public void SelectAuthorForBook(ChangeEventArgs e)
        {
            if (e.Value is string[] values && values.Length > 0)
            {
                if (int.TryParse(values[0], out int parsedAuthorId))
                {
                    newBook.AuthorId = parsedAuthorId;
                }
                else
                {
                }
            }
            else
            {
            }
        }

        public void SelectAuthorForUpdateBook(ChangeEventArgs e)
        {
            if (e.Value is string[] values && values.Length > 0)
            {
                if (int.TryParse(values[0], out int parsedAuthorId))
                {
                    updateBook.AuthorId = parsedAuthorId;
                }
                else
                {
                }
            }
            else
            {
            }
        }

        private async Task UpdateAuthor()
        {
            dbcontext.Authors.Update(updateAuthor);
            await dbcontext.SaveChangesAsync();
        }

    }
}
