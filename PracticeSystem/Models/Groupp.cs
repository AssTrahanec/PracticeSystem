using System;
using System.Collections.Generic;

#nullable disable

namespace PracticeSystem
{
    public partial class Groupp
    {
        public Groupp()
        {
            Pracs = new HashSet<Prac>();
            Studs = new HashSet<Stud>();
        }

        public string Name { get; set; }
        public string Spec { get; set; }
        public string Profile { get; set; }
        public string Edlvl { get; set; }
        public int Grid { get; set; }

        public virtual ICollection<Prac> Pracs { get; set; }
        public virtual ICollection<Stud> Studs { get; set; }
    }
}
