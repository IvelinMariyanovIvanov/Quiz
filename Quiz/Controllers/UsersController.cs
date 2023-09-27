using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize]
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

            viewModel.MultipleOptionAuthorList.Add(viewModel.CorrectAuthor);
            viewModel.MultipleOptionAuthorList.Add(viewModel.FalseAuthor1);
            viewModel.MultipleOptionAuthorList.Add(viewModel.FalseAuthor2);

            return View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AnswerQuestion(QuestionVM form, string answerValue)
        {

            if (!ModelState.IsValid)
                return View(form);

            string userId = User.Identity.GetUserId();

            if(userId == null)
            {
                TempData["error"] = "Please Log In";
                return View(form);
            }

            List<Author> allAuthors = await _unitOfWork.AuthorRepository.GetAllAsync();

            try
            {
                Answer answer = new Answer()
                {
                    QuestionId = form.Id,
                    QuoteId = form.QuoteId,
                    AnswerId = form.CorrectAuthorId
                };

                // yes or no
                if (answerValue == "yes" || answerValue == "no")
                    await SetYesOrNoAnswer(form, answerValue, answer, allAuthors);
                // multiple
                else
                    SetMultipleAnswer(form, Convert.ToInt32(answerValue), answer, allAuthors);

                await _unitOfWork.AnswerRepository.AddAsync(answer);
                await _unitOfWork.SaveAsync();

                UserAnswers answerUser = new UserAnswers()
                {
                    AnswerId = answer.Id,
                    UserId = userId
                };

                await _unitOfWork.AnswerUserRepository.AddAsync(answerUser);
                await _unitOfWork.SaveAsync();

                SetFormAuthores(form, allAuthors);
                return View(form);
            }
            catch
            {
                TempData["error"] = "Can not answer the question";

                SetFormAuthores(form, allAuthors);
                return View(form);
            }
        }

        [NonAction]
        private static void SetFormAuthores(QuestionVM form, List<Author> allAuthors)
        {
            // get author option value
            form.RandomAuthor = allAuthors.Where(a => a.Id == form.RandomAuthorId).SingleOrDefault();

            // get author options
            form.MultipleOptionAuthorList.Add(allAuthors.Where(a => a.Id == form.CorrectAuthorId).SingleOrDefault());
            form.MultipleOptionAuthorList.Add(allAuthors.Where(a => a.Id == form.FalseAuthor1Id).SingleOrDefault());
            form.MultipleOptionAuthorList.Add(allAuthors.Where(a => a.Id == form.FalseAuthor2Id).SingleOrDefault());
        }

        [NonAction]
        private void SetMultipleAnswer(QuestionVM form, int selectedAuthortId, Answer answer, List<Author> allAuthors)
        {
            Author author = allAuthors.SingleOrDefault(a => a.Id == form.CorrectAuthorId);

            if (selectedAuthortId == form.CorrectAuthorId)
            {
                answer.IsCorrect = true;
                answer.AnswerText = author.Name;
                answer.AnswerId = form.CorrectAuthorId;

                TempData["success"] = $"Correct! The right answer is: {answer.AnswerText}";
            }
            else
            {
                answer.IsCorrect = false;
                answer.AnswerText = author.Name;
                answer.AnswerId = form.CorrectAuthorId;

                TempData["error"] = $"Sorry, you are wrong! The right answer is: {answer.AnswerText}";
            }
        }

        [NonAction]
        private async Task SetYesOrNoAnswer(QuestionVM form, string answerValue, Answer answer, List<Author> allAuthors)
        {
            Author correctAuthor = allAuthors.SingleOrDefault(a => a.Id == form.CorrectAuthorId);

            if (answerValue == "yes" && form.RandomAuthorId == form.CorrectAuthorId)
            {
                answer.IsCorrect = true;
                answer.AnswerText = correctAuthor.Name;
                answer.AnswerId = form.CorrectAuthorId;

                TempData["success"] = $"Correct! The right answer is: {answer.AnswerText}";
            }
            else if (answerValue == "yes" && form.RandomAuthorId != form.CorrectAuthorId)
            {
                answer.IsCorrect = false;
                answer.AnswerText = correctAuthor.Name;
                answer.AnswerId = form.RandomAuthorId;

                TempData["error"] = $"Sorry, you are wrong! The right answer is: {answer.AnswerText}";
            }
            else if (answerValue == "no" && form.RandomAuthorId != form.CorrectAuthorId)
            {
                answer.IsCorrect = true;
                answer.AnswerText = correctAuthor.Name;
                answer.AnswerId = form.CorrectAuthorId;

                TempData["success"] = $"Correct! The right answer is: {answer.AnswerText}";
            }
            else if (answerValue == "no" && form.RandomAuthorId == form.CorrectAuthorId)
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
