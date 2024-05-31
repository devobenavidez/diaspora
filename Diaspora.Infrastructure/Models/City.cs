using System;
using System.Collections.Generic;

namespace Diaspora.Infrastructure.Models;

public partial class City
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int ProvinceId { get; set; }

    public bool? IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public int CreatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int UpdatedBy { get; set; }

    public DateTime DeletedAt { get; set; }

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual Province Province { get; set; } = null!;

    public virtual ICollection<Service> ServiceDestinationCityNavigations { get; set; } = new List<Service>();

    public virtual ICollection<Service> ServiceOriginCityNavigations { get; set; } = new List<Service>();
}
