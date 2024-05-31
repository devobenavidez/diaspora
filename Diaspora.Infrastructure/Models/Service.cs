using System;
using System.Collections.Generic;

namespace Diaspora.Infrastructure.Models;

public partial class Service
{
    public int Id { get; set; }

    public int OriginCity { get; set; }

    public int DestinationCity { get; set; }

    public int TypeId { get; set; }

    public int CourierId { get; set; }

    public int SenderId { get; set; }

    public int ReceiverId { get; set; }

    public int StatusId { get; set; }

    public decimal? Peso { get; set; }

    public decimal? Volumen { get; set; }

    public decimal? Amount { get; set; }

    public bool? IsActive { get; set; }

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

    public virtual Servicestatus Status { get; set; } = null!;

    public virtual Servicetype Type { get; set; } = null!;
}
