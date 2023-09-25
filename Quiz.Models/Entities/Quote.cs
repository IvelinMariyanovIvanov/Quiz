
using System.ComponentModel.DataAnnotations;

namespace Quiz.Models.Entities
{
    public class Quote
    {
        public int Id { get; set; }

        [Required]
        [MinLength(5)]
        public string Text { get; set; }

        public Author Author { get; set; }
    }
}
