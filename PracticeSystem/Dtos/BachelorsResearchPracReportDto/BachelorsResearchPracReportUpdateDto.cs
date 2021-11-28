using System.ComponentModel.DataAnnotations;

namespace PracticeSystem.Dtos.BachelorsResearchPracReportDto
{
    public class BachelorsResearchPracReportUpdateDto
    {
        [Required] public int Sid { get; set; }
        [Required] public int Pracid { get; set; }
        [Required] public string Pracres { get; set; }
        [Required] public string Prtask { get; set; }
        [Required] public string Pracplan { get; set; }
        [Required] public string Conclusion { get; set; }
        [Required] public string Planedesk { get; set; }
    }
}