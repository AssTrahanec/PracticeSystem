using System.ComponentModel.DataAnnotations;

namespace PracticeSystem.Dtos
{
    public class UserUpdateDto
    {
        [Required]
        public string Login { get; set; }
        
        [Required]
        public string Password { get; set; }
    }
}