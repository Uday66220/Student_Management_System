using System;
using System.Collections.Generic;

namespace SMS.Models;

public partial class Student
{
    public int RollNo { get; set; }

    public string? Name { get; set; }

    public int ClassId { get; set; }

    public int? Year { get; set; }

    public string Contact { get; set; } = null!;

    public string? Address { get; set; }

    public int? TotalMarks { get; set; }

    public virtual Class? Class { get; set; }

    public virtual Attendence? Attendence { get; set; }
}
