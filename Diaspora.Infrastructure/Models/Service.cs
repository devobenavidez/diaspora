using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Diaspora.Infrastructure.Models;

public partial class Service
{
    public int Id { get; set; }

    public int OriginCity { get; set; }

    public int DestinationCity { get; set; }

    public int CourierId { get; set; }

    public int SenderId { get; set; }

    public int ReceiverId { get; set; }

    public DateTime PickupDate { get; set; }

    [Required]
    [DefaultValue(true)]
    public bool IsActive { get; set; }

    public string PaymentId { get; set; }

    public int ServiceTypeId { get; set; }

    public DateTime CreatedAt { get; set; }

    public int CreatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int UpdatedBy { get; set; }

    public DateTime DeletedAt { get; set; }

    public virtual Courier Courier { get; set; } = null!;

    public virtual City DestinationCityNavigation { get; set; } = null!;

    public virtual City OriginCityNavigation { get; set; } = null!;

    public virtual Person Receiver { get; set; } = null!;

    public virtual Person Sender { get; set; } = null!;

    public virtual ICollection<Servicedetail> Servicedetails { get; set; } = new List<Servicedetail>();
}
