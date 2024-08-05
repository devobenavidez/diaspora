using System;
using System.Collections.Generic;

namespace Diaspora.Infrastructure.Models;

public partial class Country
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string IsoAlpha2 { get; set; } = null!;

    public string IsoAlpha3 { get; set; } = null!;

    public int IsoNumeric { get; set; }

    public bool? IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public int CreatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int UpdatedBy { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<Documenttype> Documenttypes { get; set; } = new List<Documenttype>();

    public virtual ICollection<Province> Provinces { get; set; } = new List<Province>();
}
