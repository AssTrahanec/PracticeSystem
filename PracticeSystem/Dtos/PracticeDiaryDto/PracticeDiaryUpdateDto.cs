using System;
using System.ComponentModel.DataAnnotations;

namespace PracticeSystem.Dtos.PracticeDiaryDto
{
    public class PracticeDiaryUpdateDto
    {
        [Required]
        public int Sid { get; set; }
        [Required]
        public DateTime? Date { get; set; }
        [Required]
        public string Text { get; set; }
    }
}