
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quiz.Models.Entities
{
    public class Quote
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(5)]
        public string Text { get; set; }

        [ForeignKey(nameof(AuthorId))]
        //[NotMapped]
        public Author Author { get; set; }
        public int AuthorId { get;set; }

        //[ForeignKey(nameof(QuestionId))]
        //[NotMapped]
        //public Question Question { get; set; }
        //public int QuestionId { get; set; }
    }
}
