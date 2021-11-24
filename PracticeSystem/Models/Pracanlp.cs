using System;
using System.Collections.Generic;

#nullable disable

namespace PracticeSystem
{
    public partial class Pracanlp
    {
        public int Sid { get; set; }
        public int Pracid { get; set; }
        public string Pracbase { get; set; }
        public string Prachead { get; set; }
        public string Placedesc { get; set; }
        public string Researcharea { get; set; }
        public string Personaltask { get; set; }
        public string Usedres { get; set; }
        public string Conclusion { get; set; }
        public string Usedlit { get; set; }
        public string Usedpubl { get; set; }

        public virtual Prac Prac { get; set; }
        public virtual Stud SidNavigation { get; set; }
    }
}
