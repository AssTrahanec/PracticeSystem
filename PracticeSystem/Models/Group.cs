using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PracticeSystem.Models
{
    public class Group
    {
        [Key]
        public int grid { get; set; }
        public string edlvl { get; set; }
        public string profile { get; set; }
        public string spec { get; set; }
        public string name { get; set; }
    }
}