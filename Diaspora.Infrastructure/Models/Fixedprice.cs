using System;
using System.Collections.Generic;

namespace Diaspora.Infrastructure.Models;

public partial class Fixedprice
{
    public int Id { get; set; }

    public int ServiceTypeId { get; set; }

    public decimal? FixedPrice1 { get; set; }

    public bool? IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public int CreatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int UpdatedBy { get; set; }

    public DateTime DeletedAt { get; set; }

    public virtual Cargotype ServiceType { get; set; } = null!;
}
