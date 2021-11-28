using System.ComponentModel.DataAnnotations;

namespace PracticeSystem.Dtos.PostgradsTeachingPracReportDto
{
    public class PostgradsTeachingPracReportUpdateDto
    {
        [Required] public int Sid { get; set; }
        [Required] public int Pracid { get; set; }
        [Required] public string Placedesc { get; set; }
        [Required] public string Edprog { get; set; }
        [Required] public string Personaltask { get; set; }
        [Required] public string Ptparts { get; set; }
        [Required] public string Useded { get; set; }
        [Required] public string Conclusion { get; set; }
    }
}