using System;
using System.Collections.Generic;

namespace RMASystem.DAL;

public partial class LoyaltySetupDetail
{
    public int Id { get; set; }

    public int? HeaderId { get; set; }

    public int? LineSerial { get; set; }

    public decimal? FromPoint { get; set; }

    public decimal? ToPoint { get; set; }

    public decimal? BulkValue { get; set; }

    public decimal? Value { get; set; }

    public string? InsertUid { get; set; }

    public DateTime? InsertDate { get; set; }
}
