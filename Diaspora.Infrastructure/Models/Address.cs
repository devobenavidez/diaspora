using System;
using System.Collections.Generic;

namespace Diaspora.Infrastructure.Models;

public partial class Address
{
    public int Id { get; set; }

    public string Address1 { get; set; } = null!;

    public string? Address2 { get; set; }

    public string? Address3 { get; set; }

    public int CityId { get; set; }

    public bool? IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public int CreatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int UpdatedBy { get; set; }

    public DateTime DeletedAt { get; set; }

    public virtual City City { get; set; } = null!;

    public virtual ICollection<Person> People { get; set; } = new List<Person>();
}
