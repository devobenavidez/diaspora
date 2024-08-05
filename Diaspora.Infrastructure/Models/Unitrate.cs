using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Diaspora.Infrastructure.Models;

public partial class Unitrate
{
    public int Id { get; set; }

    public int OriginCityId { get; set; }

    public int DestinationCityId { get; set; }

    public int ServiceTypeId { get; set; }

    public int? UnitRateTypeId { get; set; }

    public decimal UnitPrice { get; set; }

    [Required]
    [DefaultValue(true)]
    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public int CreatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int UpdatedBy { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual City DestinationCity { get; set; } = null!;

    public virtual City OriginCity { get; set; } = null!;

    public virtual Cargotype ServiceType { get; set; } = null!;

    public virtual Unitratetype? UnitRateType { get; set; }
}
