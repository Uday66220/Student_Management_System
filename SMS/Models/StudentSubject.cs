using System;
using System.Collections.Generic;

namespace SMS.Models;

public partial class StudentSubject
{
    public int StudentId { get; set; }

    public int SubjectId { get; set; }

    public virtual Student Student { get; set; } = null!;

    public virtual Subject Subject { get; set; } = null!;
}
