using System;
using System.Collections.Generic;

namespace SMS.Models;

public partial class Class
{
    public int ClassId { get; set; }

    public int ClassTeacherId { get; set; }

    public virtual Teacher ClassTeacher { get; set; } = null!;

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
