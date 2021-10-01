using System.ComponentModel.DataAnnotations;

namespace PracticeSystem.Models
{
    public class PracticeHead
    {
        [Key]
        public int pid { get; set; }
        public string fname { get; set; }
        public string depart { get; set; }
        public string eds { get; set; }
    }
}