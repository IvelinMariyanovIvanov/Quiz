using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quiz.Data.Migrations;
using Quiz.Data.Repositories.Interfaces;
using Quiz.Models.Entities;
using Quiz.Web.ViewModels;
using System.Security.Claims;
using UserAnswers = Quiz.Models.Entities.UserAnswers;

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
        public async Task<IActionResult> GetAllQuestionsAPI()
        {
            List<Quote> quotes =
                await _unitOfWork.QuoteRepository.GetAllAsync();

            return Json(new { data = quotes.OrderBy(i => i.Id) });
        }

        public IActionResult Questions()
        {
            return View();
        }

        public async Task<IActionResult> AnswerQuestion(int? id)
        {
            if (id == null | id == 0)
                return NotFound();

            Question question = await _unitOfWork.QuestionRepository.GetEntityAsync
                (q => q.Id == id, includeProperties: "FalseAuthor1,FalseAuthor2,CorrectAuthor,AskedQuote");

            if (question == null)
                return NotFound();

            QuestionVM viewModel = _mapper.Map<QuestionVM>(question);

            // set if CorrectAuthorId = FalseAuthor1Id
            Random rnd = new Random();
            viewModel.RandomAuthorId = rnd.Next(question.CorrectAuthorId, ++question.FalseAuthor1Id);
            Author randomAuthor = await _unitOfWork.AuthorRepository.GetByIdAsync(viewModel.RandomAuthorId);

            if (randomAuthor == null)
                randomAuthor = question.CorrectAuthor;
            else
                viewModel.RandomAuthor = randomAuthor;

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AnswerQuestion(QuestionVM form, string submit)
        {
            if (!ModelState.IsValid)
                return View(form);

            string userId = User.Identity.GetUserId();

            if(userId == null)
            {
                TempData["error"] = "Please Log In";
                return View(form);
            }

            try
            {
                Answer answer = new Answer()
                {
                    QuestionId = form.Id,
                    QuoteId = form.QuoteId,
                    AnswerId = form.CorrectAuthorId
                };

                await SetAnswer(form, submit, answer);

                await _unitOfWork.AnswerRepository.AddAsync(answer);
                await _unitOfWork.SaveAsync();

                UserAnswers answerUser = new UserAnswers()
                {
                    AnswerId = answer.Id,
                    UserId = userId
                };

                await _unitOfWork.AnswerUserRepository.AddAsync(answerUser);
                await _unitOfWork.SaveAsync();

                // get author option value
                form.RandomAuthor = await _unitOfWork.AuthorRepository.GetByIdAsync(form.RandomAuthorId);

                return View(form);
            }
            catch
            {
                TempData["error"] = "Can not answer the question";

                return View(form);
            }
        }

        [NonAction]
        private async Task SetAnswer(QuestionVM form, string submit, Answer answer)
        {
            if (submit == "yes" && form.RandomAuthorId == form.CorrectAuthorId)
            {
                Author author = await _unitOfWork.AuthorRepository.GetByIdAsync(form.CorrectAuthorId);

                answer.IsCorrect = true;
                answer.AnswerText = author.Name;
                answer.AnswerId = form.CorrectAuthorId;

                TempData["success"] = $"Correct! The right answer is: {answer.AnswerText}";
            }
            else if (submit == "yes" && form.RandomAuthorId != form.CorrectAuthorId)
            {
                Author author = await _unitOfWork.AuthorRepository.GetByIdAsync(form.CorrectAuthorId);

                answer.IsCorrect = false;
                answer.AnswerText = author.Name;
                answer.AnswerId = form.RandomAuthorId;

                TempData["error"] = $"Sorry, you are wrong! The right answer is: {answer.AnswerText}";
            }
            else if (submit == "no" && form.RandomAuthorId != form.CorrectAuthorId)
            {
                Author author = await _unitOfWork.AuthorRepository.GetByIdAsync(form.CorrectAuthorId);

                answer.IsCorrect = true;
                answer.AnswerText = author.Name;
                answer.AnswerId = form.CorrectAuthorId;

                TempData["success"] = $"Correct! The right answer is: {answer.AnswerText}";
            }
            else if (submit == "no" && form.RandomAuthorId == form.CorrectAuthorId)
            {
                Author author = await _unitOfWork.AuthorRepository.GetByIdAsync(form.RandomAuthorId);

                answer.IsCorrect = false;
                answer.AnswerText = author.Name;
                answer.AnswerId = form.RandomAuthorId;

                TempData["error"] = $"Sorry, you are wrong! The right answer is: {answer.AnswerText}";
            }
        }
    }
}
