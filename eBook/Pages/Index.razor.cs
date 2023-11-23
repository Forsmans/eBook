using Microsoft.AspNetCore.Components;

namespace eBook.Pages
{
    public partial class Index
    {
        private void RedirectToBooks()
        {
            NavigationManager.NavigateTo("/Books");
        }
    }
}
