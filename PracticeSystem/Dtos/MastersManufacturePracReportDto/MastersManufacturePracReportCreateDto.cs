using System.ComponentModel.DataAnnotations;

namespace PracticeSystem.Dtos.MastersManufacturePracReportDto
{
    public class MastersManufacturePracReportCreateDto
    {
        [Required] public int Sid { get; set; }
        [Required] public int Pracid { get; set; }
        [Required] public string Intro { get; set; }
        [Required] public string Basechar { get; set; }
        [Required] public string Equipchar { get; set; }
        [Required] public string Progchar { get; set; }
        [Required] public string Result { get; set; }
        [Required] public string Usedres { get; set; }

    }
}