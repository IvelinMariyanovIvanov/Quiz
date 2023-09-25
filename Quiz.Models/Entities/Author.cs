using System.ComponentModel.DataAnnotations;

namespace Quiz.Models.Entities
{
    public class Author
    {
        [Key]
        public int Id { get; set; }

        public List<Quote> Quotes { get; set; }
    }
}
