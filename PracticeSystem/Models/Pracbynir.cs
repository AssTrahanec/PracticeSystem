using System;
using System.Collections.Generic;

#nullable disable

namespace PracticeSystem
{
    public partial class Pracbynir
    {
        public int Sid { get; set; }
        public int Pracid { get; set; }
        public string Pracres { get; set; }
        public string Prtask { get; set; }
        public string Pracplan { get; set; }
        public string Conclusion { get; set; }
        public string Planedesk { get; set; }

        public virtual Prac Prac { get; set; }
        public virtual Stud SidNavigation { get; set; }
    }
}
