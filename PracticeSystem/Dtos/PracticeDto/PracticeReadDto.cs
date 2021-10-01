using System;

namespace PracticeSystem.Dtos.PracticeDto
{
    public class PracticeReadDto
    {
        public int pracid { get; set; }
        public int pid { get; set; }
        public int grid { get; set; }
        public string type { get; set; }
        public string name { get; set; }
        public DateTime datestart { get; set; }
        public DateTime dateend { get; set; }
    }
}