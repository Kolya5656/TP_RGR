using System;
using System.Collections.Generic;

namespace TP_RGR
{
    public partial class Mark
    {
        public int Idmarks { get; set; }
        public int Mark1 { get; set; }
        public int RecordBook { get; set; }
        public string? Status { get; set; }
        public DateOnly? StatusDate { get; set; }
        public int Idsubject { get; set; }

        public virtual Subject IdsubjectNavigation { get; set; } = null!;
        public virtual Student RecordBookNavigation { get; set; } = null!;
    }
}
