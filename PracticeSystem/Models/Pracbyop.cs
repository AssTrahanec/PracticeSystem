using System;
using System.Collections.Generic;

#nullable disable

namespace PracticeSystem
{
    public partial class Pracbyop
    {
        public int Sid { get; set; }
        public int Pracid { get; set; }
        public string Intro { get; set; }
        public string Taskresults { get; set; }
        public string Datacodetask { get; set; }
        public string Programmingtask { get; set; }
        public string Conclusion { get; set; }

        public virtual Prac Prac { get; set; }
        public virtual Stud SidNavigation { get; set; }
    }
}
