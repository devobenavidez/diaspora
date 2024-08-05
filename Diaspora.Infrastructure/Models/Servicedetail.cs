using System;
using System.Collections.Generic;

namespace Diaspora.Infrastructure.Models;

public partial class Servicedetail
{
    public int Id { get; set; }

    public string? Content { get; set; }

    public int? ServiceId { get; set; }

    public int? CargoTypeId { get; set; }

    public decimal? Weight { get; set; }

    public decimal? Height { get; set; }

    public decimal? Width { get; set; }

    public decimal? Length { get; set; }

    public decimal DeclaredValue { get; set; }

    public decimal? Amount { get; set; }

    public int? StatusId { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual Service? Service { get; set; }
}
