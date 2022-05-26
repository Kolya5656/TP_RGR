using System;
using System.Collections.Generic;

namespace TP_RGR
{
    public partial class Faculty
    {
        public Faculty()
        {
            Groups = new HashSet<Group>();
        }

        public int Idfaculty { get; set; }
        public string Name { get; set; } = null!;
        public string? Status { get; set; }
        public DateOnly? StatusDate { get; set; }

        public virtual ICollection<Group> Groups { get; set; }
    }
}
