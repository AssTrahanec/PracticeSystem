using System.ComponentModel.DataAnnotations;

namespace PracticeSystem.Dtos.BachelorsPredegreePracReportDto
{
    public class BachelorsPredegreePracReportCreateDto
    {
        [Required] public int Sid { get; set; }
        [Required] public int Pracid { get; set; }
        [Required] public string Intro { get; set; }
        [Required] public string Basechar { get; set; }
        [Required] public string Taskresult { get; set; }
        [Required] public string Usedres { get; set; }
    }
}