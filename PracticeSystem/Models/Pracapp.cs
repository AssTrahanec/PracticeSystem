using System;
using System.Collections.Generic;

#nullable disable

namespace PracticeSystem
{
    public partial class Pracapp
    {
        public int Sid { get; set; }
        public int Pracid { get; set; }
        public string Placedesc { get; set; }
        public string Edprog { get; set; }
        public string Personaltask { get; set; }
        public string Ptparts { get; set; }
        public string Useded { get; set; }
        public string Conclusion { get; set; }

        public virtual Prac Prac { get; set; }
        public virtual Stud SidNavigation { get; set; }
    }
}
