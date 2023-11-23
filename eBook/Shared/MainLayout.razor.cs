using Microsoft.AspNetCore.Components;

namespace eBook.Shared
{
    public partial class MainLayout
    {
        
        public string GetCartAmount()
        {
            string cartAmount = null;
                
                if(Program.cart != null && Program.cart.GetCartCount() != "0")
                {
                    cartAmount = $"({Program.cart.GetCartCount()})";
                }

            return cartAmount;
        }
    }
}
