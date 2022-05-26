using System;
using System.Collections.Generic;

namespace TP_RGR
{
    public partial class Lecturer
    {
        public Lecturer()
        {
            Subjects = new HashSet<Subject>();
        }

        public int Idlecturer { get; set; }
        public string Name { get; set; } = null!;
        public string SurName { get; set; } = null!;
        public string Patronmyc { get; set; } = null!;
        public string? Status { get; set; }
        public DateOnly? StatusDate { get; set; }

        public virtual ICollection<Subject> Subjects { get; set; }
    }
}
