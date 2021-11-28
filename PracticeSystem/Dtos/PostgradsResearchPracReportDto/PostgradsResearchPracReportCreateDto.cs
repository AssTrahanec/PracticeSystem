using System.ComponentModel.DataAnnotations;

namespace PracticeSystem.Dtos.PostgradsResearchPracReportDto
{
    public class PostgradsResearchPracReportCreateDto
    {
        [Required] public int Sid { get; set; }
        [Required] public int Pracid { get; set; }
        [Required] public string Pracbase { get; set; }
        [Required] public string Prachead { get; set; }
        [Required] public string Placedesc { get; set; }
        [Required] public string Researcharea { get; set; }
        [Required] public string Personaltask { get; set; }
        [Required] public string Usedres { get; set; }
        [Required] public string Conclusion { get; set; }
        [Required] public string Usedlit { get; set; }
        [Required] public string Usedpubl { get; set; }
    }
}