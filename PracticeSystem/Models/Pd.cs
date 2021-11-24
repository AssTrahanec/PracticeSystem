using System;
using System.Collections.Generic;

#nullable disable

namespace PracticeSystem
{
    public partial class Pd
    {
        public int Pracid { get; set; }
        public int Sid { get; set; }
        public DateTime? Date { get; set; }
        public string Text { get; set; }

        public virtual Prac Prac { get; set; }
        public virtual Stud SidNavigation { get; set; }
    }
}
