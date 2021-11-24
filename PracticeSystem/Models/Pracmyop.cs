using System;
using System.Collections.Generic;

#nullable disable

namespace PracticeSystem
{
    public partial class Pracmyop
    {
        public int Sid { get; set; }
        public int Pracid { get; set; }
        public string Intro { get; set; }
        public string Basechar { get; set; }
        public string Equipchar { get; set; }
        public string Progchar { get; set; }
        public string Result { get; set; }
        public string Usedres { get; set; }

        public virtual Prac Prac { get; set; }
        public virtual Stud SidNavigation { get; set; }
    }
}
