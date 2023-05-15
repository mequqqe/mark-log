using System.ComponentModel.DataAnnotations;

namespace EnglishPractice.Models
{
    public class Month
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
