using System;
using System.Collections.Generic;

namespace SMS.Models;

public partial class SubjectMark
{
    public int StudentId { get; set; }

    public int SubjectId { get; set; }

    public int? Marks { get; set; }

    public virtual Student Student { get; set; } = null!;

    public virtual Subject Subject { get; set; } = null!;
}
