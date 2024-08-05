using System;
using System.Collections.Generic;

namespace Diaspora.Infrastructure.Models;

public partial class Migration
{
    public int Id { get; set; }

    public string Filename { get; set; } = null!;

    public DateTime? AppliedAt { get; set; }
}
