using System;
using System.Collections.Generic;

#nullable disable

namespace PracticeSystem
{
    public partial class Prac
    {
        public Prac()
        {
            Pds = new HashSet<Pd>();
            Pracanis = new HashSet<Pracani>();
            Pracanlps = new HashSet<Pracanlp>();
            Pracapps = new HashSet<Pracapp>();
            Pracbpdps = new HashSet<Pracbpdp>();
            Pracbptps = new HashSet<Pracbptp>();
            Pracbynirs = new HashSet<Pracbynir>();
            Pracbyops = new HashSet<Pracbyop>();
            Pracmpnirs = new HashSet<Pracmpnir>();
            Pracmptps = new HashSet<Pracmptp>();
            Pracmyops = new HashSet<Pracmyop>();
            Preferals = new HashSet<Preferal>();
        }

        public int Pid { get; set; }
        public int Grid { get; set; }
        public string Type { get; set; }
        public int? Name { get; set; }
        public DateTime? Datestart { get; set; }
        public DateTime? Dateend { get; set; }
        public int Pracid { get; set; }

        public virtual Groupp Gr { get; set; }
        public virtual Phead PidNavigation { get; set; }
        public virtual ICollection<Pd> Pds { get; set; }
        public virtual ICollection<Pracani> Pracanis { get; set; }
        public virtual ICollection<Pracanlp> Pracanlps { get; set; }
        public virtual ICollection<Pracapp> Pracapps { get; set; }
        public virtual ICollection<Pracbpdp> Pracbpdps { get; set; }
        public virtual ICollection<Pracbptp> Pracbptps { get; set; }
        public virtual ICollection<Pracbynir> Pracbynirs { get; set; }
        public virtual ICollection<Pracbyop> Pracbyops { get; set; }
        public virtual ICollection<Pracmpnir> Pracmpnirs { get; set; }
        public virtual ICollection<Pracmptp> Pracmptps { get; set; }
        public virtual ICollection<Pracmyop> Pracmyops { get; set; }
        public virtual ICollection<Preferal> Preferals { get; set; }
    }
}
