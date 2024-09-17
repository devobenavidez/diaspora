using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Diaspora.Infrastructure.Models;

public partial class Person
{
    public int Id { get; set; }

    public string DocumentIdentifier { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string? LastName { get; set; }

    public string Email { get; set; } = null!;

    public DateTime? BirthDate { get; set; }

    public int DocumentTypeId { get; set; }

    public int PersonTypeId { get; set; }

    public int? AddressId { get; set; }

    public int? UserId { get; set; }

    [Required]
    [DefaultValue(true)]
    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public int CreatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int UpdatedBy { get; set; }

    public DateTime DeletedAt { get; set; }

    public virtual Address? Address { get; set; }

    public virtual Documenttype DocumentType { get; set; } = null!;

    public virtual Persontype PersonType { get; set; } = null!;

    public virtual ICollection<Service> ServiceReceivers { get; set; } = new List<Service>();

    public virtual ICollection<Service> ServiceSenders { get; set; } = new List<Service>();

    public virtual User? User { get; set; }
}
