using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Diaspora.Infrastructure.Models;

public partial class Courier
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public decimal CubicFactor { get; set; }

    public bool NeedsDivision { get; set; }

    [Required]
    [DefaultValue(true)]
    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public int CreatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int UpdatedBy { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<Service> Services { get; set; } = new List<Service>();
}
