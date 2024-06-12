using System;
using System.Collections.Generic;

namespace SMS.Models;

public partial class Teacher
{
    public int TeacherId { get; set; }

    public string Name { get; set; } = null!;

    public string? Contact { get; set; }

    public string? Address { get; set; }

    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();
}
