using System;
using System.ComponentModel.DataAnnotations;

namespace PracticeSystem.Dtos.PracticeDto
{
    public class PracticeUpdateDto
    {
        [Required]
        public int pid { get; set; }
        [Required]
        public int grid { get; set; }
        [Required]
        public string type { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public DateTime datestart { get; set; }
        [Required]
        public DateTime dateend { get; set; }
    }
}