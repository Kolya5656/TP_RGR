using System;
using System.Collections.Generic;

namespace TP_RGR
{
    public partial class Group
    {
        public Group()
        {
            Students = new HashSet<Student>();
        }

        public int Idgroups { get; set; }
        public string Name { get; set; } = null!;
        public int SpecialityCode { get; set; }
        public DateOnly DateOfFormation { get; set; }
        public string? Status { get; set; }
        public DateOnly? StatusDate { get; set; }
        public int FacultyId { get; set; }

        public virtual Faculty Faculty { get; set; } = null!;
        public virtual ICollection<Student> Students { get; set; }
    }
}
