using System;
using System.Collections.Generic;

namespace Diaspora.Infrastructure.Models;

public partial class Country
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public bool? IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public int CreatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int UpdatedBy { get; set; }

    public DateTime DeletedAt { get; set; }

    public virtual ICollection<Documenttype> Documenttypes { get; set; } = new List<Documenttype>();

    public virtual ICollection<Province> Provinces { get; set; } = new List<Province>();
}
