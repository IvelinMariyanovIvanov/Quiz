using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Quiz.Data.Repositories.Interfaces;
using Quiz.Models.Entities;
using Quiz.Web.ViewModels;

namespace Quiz.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public UsersController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllQuotesAPI()
        {
            List<Quote> quotes =
                await _unitOfWork.QuoteRepository.GetAllAsync();

            return Json(new { data = quotes.OrderBy(i => i.Id) });
        }

        public IActionResult Quotes()
        {
            return View();
        }

        public async Task<IActionResult> AnswerQuestion(int? id)
        {
            if (id == null | id == 0)
                return NotFound();

            Question question = await _unitOfWork.QuestionRepository.GetEntityAsync
                (q => q.Id == id, includeTables: "FalseAuthor1,FalseAuthor2,CorrectAuthor,AskedQuote");

            if (question == null)
                return NotFound();

            return View("AnswerQuestion", question);
        }
    }
}
