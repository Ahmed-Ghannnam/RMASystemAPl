using System;
using System.Collections.Generic;

namespace RMASystem.DAL;

public partial class RetailCustomerPointsStatement
{
    public int Id { get; set; }

    public int? CusId { get; set; }

    public DateTime? TransDate { get; set; }

    public string? Description { get; set; }

    public decimal? Debit { get; set; }

    public decimal? Credit { get; set; }

    public decimal? Balance { get; set; }

    public decimal? Value { get; set; }

    public int? TransType { get; set; }

    public string? RefNo { get; set; }

    public string? DocumentNo { get; set; }

    public int? PostFlag { get; set; }

    public DateTime? PostDate { get; set; }

    public string? InsertUid { get; set; }

    public DateTime? InsertDate { get; set; }

    public DateTime? ApplyDate { get; set; }

    public DateTime? ExpiryDate { get; set; }

    public decimal? RemainingPoints { get; set; }
}
