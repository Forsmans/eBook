using eBook.Models;
using Microsoft.AspNetCore.Components;

namespace eBook.Pages
{
    public partial class Register
    {
        private Customer newCustomer = new Customer();

        private async Task RegisterUser()
        {
            dbcontext.Customers.Add(newCustomer);
            await dbcontext.SaveChangesAsync();

            Navigation.NavigateTo("/User");
        }
    }
}
