using System;
using System.ComponentModel.DataAnnotations;

namespace PracticeSystem.Models
{
    public class Practice
    {
        [Key]
        public int pracid { get; set; }
        public int pid { get; set; }
        public int grid { get; set; }
        public string type { get; set; }
        public string name { get; set; }
        public DateTime datestart { get; set; }
        public DateTime dateend { get; set; }
    }
}