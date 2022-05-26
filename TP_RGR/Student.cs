using System;
using System.Collections.Generic;

namespace TP_RGR
{
    public partial class Student
    {
        public Student()
        {
            Marks = new HashSet<Mark>();
        }

        public int RecordBook { get; set; }
        public string Name { get; set; } = null!;
        public string SurName { get; set; } = null!;
        public string Patronymic { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string TelNumber { get; set; } = null!;
        public string? Status { get; set; }
        public DateOnly? StatusDate { get; set; }
        public int GroupId { get; set; }

        public virtual Group Group { get; set; } = null!;
        public virtual ICollection<Mark> Marks { get; set; }
    }
}
