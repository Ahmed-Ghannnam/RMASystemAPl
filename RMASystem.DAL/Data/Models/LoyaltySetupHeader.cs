using System;
using System.Collections.Generic;

namespace RMASystem.DAL;

public partial class LoyaltySetupHeader
{
    public int Id { get; set; }

    public int? SetupType { get; set; }

    public DateTime? ApplyDate { get; set; }

    public bool? Status { get; set; }

    public string? InsertUid { get; set; }

    public DateTime? InsertDate { get; set; }

    public int? DaysToApply { get; set; }

    public int? DaysTotExpiry { get; set; }

    public decimal? Minimum { get; set; }

    public decimal? GiftPoints { get; set; }
}
