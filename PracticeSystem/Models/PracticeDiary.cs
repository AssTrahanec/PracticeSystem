using System;
using System.ComponentModel.DataAnnotations;

namespace PracticeSystem.Models
{
    public class PracticeDiary
    {
        [Key] public int PracticeId { get; set; }
        public int StudentId { get; set; }
        public DateTime PracticeDate { get; set; }
        public string Text { get; set; }
    }
}