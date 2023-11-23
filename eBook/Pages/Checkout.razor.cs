using eBook.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity.Core.Common.CommandTrees;

namespace eBook.Pages
{
    public partial class Checkout
    {
        private List<StockBalance> stockbalance = new List<StockBalance>();

        protected override async Task OnInitializedAsync()
        {
            stockbalance = await dbcontext.StockBalances.ToListAsync();
            RemoveFromStock();
        }

        public void RemoveFromStock()
        {
            foreach (var book in Program.cart.GetCartBooks())
            {
                foreach (var stock in stockbalance)
                {
                    if (book.Isbn13 == stock.Isbn13 && Program.choosenStore.StoreId == stock.StoreId)
                    {
                        UpdateStock(stock);
                        stock.Quantity = stock.Quantity - 1;

                    }
                }
            }
        }

        private async Task UpdateStock(StockBalance stock)
        {
            dbcontext.StockBalances.Update(stock);
            await dbcontext.SaveChangesAsync();

        }

        private decimal? GetTotal()
        {
            decimal? sum = 0;
            foreach (var book in Program.cart.GetCartBooks())
            {
                sum += book.Price;
            }
            return sum;
        }

        
    }
}
