using System;
using System.Collections.Generic;

namespace eBook.Models;

public partial class OrderDetail
{
    public int OrderDetailId { get; set; }

    public int? OrderId { get; set; }

    public string? Isbn13 { get; set; }

    public virtual Book? Isbn13Navigation { get; set; }

    public virtual Order? Order { get; set; }
}
