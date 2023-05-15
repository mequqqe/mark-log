namespace EnglishPractice.Models
{
    public class DayVisit
    {
        public int Id { get; set; }

        public int MonthId { get; set; }

        public int Day { get; set; }

        public int SrudentId { get; set; }

        public bool IsVisit { get; set; }
    }
}
