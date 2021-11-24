using System;
using System.Collections.Generic;

#nullable disable

namespace PracticeSystem
{
    public partial class User
    {
        public int Uid { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public virtual Phead Phead { get; set; }
        public virtual Stud Stud { get; set; }
    }
}
