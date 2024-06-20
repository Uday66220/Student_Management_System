using System.ComponentModel.DataAnnotations.Schema;

namespace SMS.Models
{
    public class Attendence
    {
        public int Student_id { get; set; }

        public int attendence { get; set; }

        public virtual Student? Student { get; set; }
    }
}
