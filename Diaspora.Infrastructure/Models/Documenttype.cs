using System;
using System.Collections.Generic;

namespace Diaspora.Infrastructure.Models;

public partial class Documenttype
{
    public int Id { get; set; }

    public string? Description { get; set; }

    /// <summary>
    /// Esta columna se crea por que es posible que cada país tenga sus propios tipo de documento 
    /// </summary>
    public int CountryId { get; set; }

    public sbyte IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public int CreatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int UpdatedBy { get; set; }

    public DateTime DeletedAt { get; set; }

    public virtual Country Country { get; set; } = null!;

    public virtual ICollection<Person> People { get; set; } = new List<Person>();
}
