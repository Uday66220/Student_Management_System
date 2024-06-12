using System;
using System.Collections.Generic;

namespace SMS.Models;

public partial class Rank
{
    public int Studentid { get; set; }

    public int Classid { get; set; }

    public int Subjectid { get; set; }

    public int? Marks { get; set; }
}
