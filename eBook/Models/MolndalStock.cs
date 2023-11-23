using System;
using System.Collections.Generic;

namespace eBook.Models;

public partial class MolndalStock
{
    public int? Quantity { get; set; }

    public string? Title { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Isbn13 { get; set; }

    public string? Language { get; set; }

    public int? NumberOfPages { get; set; }

    public DateTime? PublishDate { get; set; }

    public decimal? Price { get; set; }
}
