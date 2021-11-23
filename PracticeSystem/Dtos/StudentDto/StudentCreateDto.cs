using System.ComponentModel.DataAnnotations;

namespace PracticeSystem.Dtos.Student
{
    public class StudentCreateDto
    {
        [Required]
        public int sid { get; set; }
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