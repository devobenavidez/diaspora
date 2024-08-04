using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Diaspora.Infrastructure.Models;

public partial class City
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int ProvinceId { get; set; }

    public int GeoNameId { get; set; }

    [Required]
    [DefaultValue(true)]
    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public int CreatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int UpdatedBy { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual Province Province { get; set; } = null!;

    public virtual ICollection<Service> ServiceDestinationCityNavigations { get; set; } = new List<Service>();

    public virtual ICollection<Service> ServiceOriginCityNavigations { get; set; } = new List<Service>();

    public virtual ICollection<Unitrate> UnitrateDestinationCities { get; set; } = new List<Unitrate>();

    public virtual ICollection<Unitrate> UnitrateOriginCities { get; set; } = new List<Unitrate>();
}
