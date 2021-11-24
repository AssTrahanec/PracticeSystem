using System;
using System.Collections.Generic;

#nullable disable

namespace PracticeSystem
{
    public partial class Pracani
    {
        public int Sid { get; set; }
        public int Pracid { get; set; }
        public string Conf { get; set; }
        public int? Halfyear { get; set; }
        public string Workbefore { get; set; }
        public string Publicw { get; set; }
        public string Other { get; set; }
        public string Review { get; set; }

        public virtual Prac Prac { get; set; }
        public virtual Stud SidNavigation { get; set; }
    }
}
