using System.ComponentModel.DataAnnotations;

namespace PracticeSystem.Dtos
{
    public class StudentUpdateDto
    {
        [Required]
        public int grid { get; set; }
        [Required]
        public string fname { get; set; }
        [Required]
        public string eds { get; set; }
        [Required]
        public bool state { get; set; }
    }
}