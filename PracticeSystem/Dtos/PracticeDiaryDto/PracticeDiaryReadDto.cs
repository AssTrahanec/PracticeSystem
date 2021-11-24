using System;

namespace PracticeSystem.Dtos.PracticeDiaryDto
{
    public class PracticeDiaryReadDto
    {
        public int Pracid { get; set; }
        public int Sid { get; set; }
        public DateTime? Date { get; set; }
        public string Text { get; set; }
    }
}