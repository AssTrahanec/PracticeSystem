using System.ComponentModel.DataAnnotations;

namespace PracticeSystem.Models
{
    public class Student
    {
        [Key]
        public int sid { get; set; }
        public int grid { get; set; }
        public string fname { get; set; }
        public string eds { get; set; }
        public bool state { get; set; }
        public User user { get; set; }
    }
}