using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Quiz.Models.Entities
{
    public class Author
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        //[JsonIgnore]
        [NotMapped]
        public List<Quote> Quotes { get; set; }
    }
}
