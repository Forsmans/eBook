using System;
using System.Collections.Generic;

namespace eBook.Models;

public partial class Payment
{
    public int TransactionId { get; set; }

    public int? OrderId { get; set; }

    public decimal? PaymentAmount { get; set; }

    public DateTime? PaymentDate { get; set; }

    public string? PaymentStatus { get; set; }

    public virtual Order? Order { get; set; }
}
