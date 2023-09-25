using Microsoft.AspNetCore.Mvc.Rendering;
using Quiz.Models.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Quiz.Web.ViewModels
{
    public class CreateQuoteVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a text for quote")]
        [MinLength(5)]
        public string Text { get; set; }

        [DisplayName("Author")]
        [Range(1, int.MaxValue)]
        [Required(ErrorMessage = "Please select an Author")]
        public int AuthorId { get; set; }

        public IEnumerable<SelectListItem> AuthorsDropDown { get; set; }

        public Author Author { get; set; }
    }
}
