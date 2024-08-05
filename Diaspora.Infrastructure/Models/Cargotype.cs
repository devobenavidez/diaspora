using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Diaspora.Infrastructure.Models;

public partial class Cargotype
{
    public int Id { get; set; }

    public string Description { get; set; } = null!;

    [Required]
    [DefaultValue(true)]
    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public int CreatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int UpdatedBy { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<Fixedprice> Fixedprices { get; set; } = new List<Fixedprice>();

    public virtual ICollection<Unitrate> Unitrates { get; set; } = new List<Unitrate>();
}
