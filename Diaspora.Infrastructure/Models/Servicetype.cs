using System;
using System.Collections.Generic;

namespace Diaspora.Infrastructure.Models;

public partial class Servicetype
{
    public int Id { get; set; }

    public string Description { get; set; } = null!;

    public bool? IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public int CreatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int UpdatedBy { get; set; }

    public DateTime DeletedAt { get; set; }

    public virtual ICollection<Fixedprice> Fixedprices { get; set; } = new List<Fixedprice>();

    public virtual ICollection<Service> Services { get; set; } = new List<Service>();
}
