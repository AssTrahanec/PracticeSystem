using System.ComponentModel.DataAnnotations;

namespace PracticeSystem.Models
{
    public class PracticeReferal
    {
        public int PracticeId { get; set; }
        public int StudentId { get; set; }
    }
}