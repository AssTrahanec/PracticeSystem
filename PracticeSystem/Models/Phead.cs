using System;
using System.Collections.Generic;

#nullable disable

namespace PracticeSystem
{
    public partial class Phead
    {
        public Phead()
        {
            Pracs = new HashSet<Prac>();
        }

        public int Pid { get; set; }
        public string Fname { get; set; }
        public string Depart { get; set; }
        public string Eds { get; set; }

        public virtual User PidNavigation { get; set; }
        public virtual ICollection<Prac> Pracs { get; set; }
    }
}
