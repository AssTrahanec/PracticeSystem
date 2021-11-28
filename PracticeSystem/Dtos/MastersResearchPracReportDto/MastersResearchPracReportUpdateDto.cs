using System.ComponentModel.DataAnnotations;

namespace PracticeSystem.Dtos.MastersResearchPracReportDto
{
    public class MastersResearchPracReportUpdateDto
    {
        [Required] public int Sid { get; set; }
        [Required] public int Pracid { get; set; }
        [Required] public string Conf { get; set; }
        [Required] public int? Halfyear { get; set; }
        [Required] public string Workbefore { get; set; }
        [Required] public string Publicw { get; set; }
        [Required] public string Other { get; set; }
        [Required] public string Review { get; set; }
    }
}