using System.ComponentModel.DataAnnotations;

namespace PracticeSystem.Dtos.BachelorsIntroductionPracReportDto
{
    public class BachelorsIntroductionPracReportUpdateDto
    {
        [Required] public int Sid { get; set; }
        [Required] public int Pracid { get; set; }
        [Required] public string Intro { get; set; }
        [Required] public string Taskresults { get; set; }
        [Required] public string Datacodetask { get; set; }
        [Required] public string Programmingtask { get; set; }
        [Required] public string Conclusion { get; set; }
    }
}