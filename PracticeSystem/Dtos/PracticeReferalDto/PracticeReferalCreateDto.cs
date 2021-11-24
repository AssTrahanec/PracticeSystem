using System;
using System.ComponentModel.DataAnnotations;

namespace PracticeSystem.Dtos.PracticeReferalDto
{
    public class PracticeReferalCreateDto
    {
        [Required] public int Pracid { get; set; }
        [Required] public int Sid { get; set; }
        [Required] public string Practype { get; set; }
        [Required] public string Pracbase { get; set; }
        [Required] public string City { get; set; }
        [Required] public string Orderr { get; set; }
        [Required] public DateTime? Orderdate { get; set; }
        [Required] public int? Contractnum { get; set; }
        [Required] public DateTime? Contractdate { get; set; }
        [Required]public int? Refnum { get; set; }
        [Required]public int? Univyear { get; set; }
        [Required]public string Prachead { get; set; }
        [Required]public string Dean { get; set; }
        [Required]public string Productionobj { get; set; }
        [Required]public string Ptheme { get; set; }
        [Required]public string Listmat { get; set; }
        [Required]public string Listgraph { get; set; }
        [Required]public string Pracresult { get; set; }
        [Required]public string Practaskresult { get; set; }
        [Required]public string Studchar { get; set; }
        [Required]public string Comment { get; set; }
        [Required]public string Recomend { get; set; }
        [Required]public string Commentd { get; set; }
        [Required]public string Faculty { get; set; }
        [Required]public string Headpos { get; set; }
        [Required]public string Headposd { get; set; }
        [Required]public string Pracresultd { get; set; }
        [Required]public string Practaskresultd { get; set; }
        [Required]public string Studchard { get; set; }
        [Required]public string Uhead { get; set; }
    }
}