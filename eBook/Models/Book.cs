using System;
using System.Collections.Generic;

namespace eBook.Models;

public partial class Book
{
    public string Isbn13 { get; set; } = null!;

    public string? Title { get; set; }

    public int? AuthorId { get; set; }

    public string? Language { get; set; }

    public DateTime? PublishDate { get; set; }

    public decimal? Price { get; set; }

    public int? NumberOfPages { get; set; }

    public string? BookCover { get; set; }

    public virtual Author? Author { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual ICollection<StockBalance> StockBalances { get; set; } = new List<StockBalance>();
}
