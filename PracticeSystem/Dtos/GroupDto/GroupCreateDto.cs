using System.ComponentModel.DataAnnotations;

namespace PracticeSystem.Dtos.Group
{
    public class GroupCreateDto
    {
        [Required]
        public int edlvl { get; set; }
        [Required]
        public string profile { get; set; }
        [Required]
        public string spec { get; set; }
        [Required]
        public string name { get; set; }
    }
}