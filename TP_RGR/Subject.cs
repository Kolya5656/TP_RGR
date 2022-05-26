using System;
using System.Collections.Generic;

namespace TP_RGR
{
    public partial class Subject
    {
        public Subject()
        {
            Marks = new HashSet<Mark>();
        }

        public int Idsubjects { get; set; }
        public string Name { get; set; } = null!;
        public string? Status { get; set; }
        public DateOnly? StatusDate { get; set; }
        public int Idlecturer { get; set; }

        public virtual Lecturer IdlecturerNavigation { get; set; } = null!;
        public virtual ICollection<Mark> Marks { get; set; }
    }
}
