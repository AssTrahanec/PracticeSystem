using System.ComponentModel.DataAnnotations;

namespace PracticeSystem.Dtos.PracticeHeadsDto
{
    public class PracticeHeadCreateDto
    {
        [Required]
        public int pid { get; set; }
        [Required]
        public string fname { get; set; }
        [Required]
        public string depart { get; set; }
        [Required]
        public string eds { get; set; }
    }
}