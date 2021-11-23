using System.ComponentModel.DataAnnotations;

namespace PracticeSystem.Models
{
    public class User
    {
        [Key]
        public int uid { get; set; }
        public string login { get; set; }
        public string password { get; set; }
    }
}