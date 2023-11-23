using eBook.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace eBook.Pages
{
    public partial class Login
    {
        private string password;
        private string email;
        private List<Customer> customers = new List<Customer>();

        public void Register()
        {
            Navigation.NavigateTo("/Register");
        }

        protected override async Task OnInitializedAsync()
        {
            customers = await dbcontext.Customers.ToListAsync();
        }

        private void SignIn()
        {
            if (password != null && email != null)
            {
                foreach (var customer in customers)
                {
                    if (customer.Email.ToLower() == email.ToLower())
                    {
                        if (customer.Password == password)
                        {
                            // Login Success!
                            // Toaster?
                            Program.CurrentUser = customer;
                            Navigation.NavigateTo("/User");
                        }
                        else
                        {
                            // Wrong Password!
                            // Toaster ?
                        }
                    }
                }
                //Email not found, register new? 
            }
        }
    }
}
