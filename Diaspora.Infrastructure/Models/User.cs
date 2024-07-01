﻿using System;
using System.Collections.Generic;

namespace Diaspora.Infrastructure.Models;

public partial class User
{
    public int Id { get; set; }

    public string UserName { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public int CreatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int UpdatedBy { get; set; }

    public DateTime? DeletedAt { get; set; }
    public byte[] Salt { get; set; }

    public virtual ICollection<Person> People { get; set; } = new List<Person>();
}
