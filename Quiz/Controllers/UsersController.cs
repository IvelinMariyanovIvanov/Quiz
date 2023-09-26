using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quiz.Data.Migrations;
using Quiz.Data.Repositories.Interfaces;
using Quiz.Models.Entities;
using Quiz.Web.ViewModels;
using System.Security.Claims;

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
            viewModel.RandomAuthorId = rnd.Next(question.CorrectAuthorId, question.FalseAuthor1Id + 1);
            Author randomAuthor = await _unitOfWork.AuthorRepository.GetByIdAsync(id);

            if (randomAuthor == null)
                randomAuthor = question.CorrectAuthor;

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AnswerQuestion(QuestionVM form, string submit)
        {
            if (!ModelState.IsValid)
                return View(form);


            try
            {
                Answer answer = new Answer()
                {
                    QuestionId = form.Id,
                    QuoteId = form.QuoteId,
                    AnswerId = form.CorrectAuthorId
                };

                if (submit == "yes" && form.RandomAuthorId == form.CorrectAuthorId)
                {
                    Author author = await _unitOfWork.AuthorRepository.GetByIdAsync(form.CorrectAuthorId);

                    answer.IsCorrect = true;
                    answer.AnswerText = author.Name;
                    answer.AnswerId = form.CorrectAuthor.Id;
                }
                else if(submit == "no" && form.RandomAuthorId == form.CorrectAuthorId)
                {
                    Author author = await _unitOfWork.AuthorRepository.GetByIdAsync(form.RandomAuthorId);

                    answer.IsCorrect = false;
                    answer.AnswerText = author.Name;
                    answer.AnswerId = form.RandomAuthorId;
                }

                await _unitOfWork.AnswerRepository.AddAsync(answer);


                Models.Entities.UserAnswers answerUser = new Models.Entities.UserAnswers()
                {
                    AnswerId = answer.Id,
                    UserId = User.Identity.GetUserId()
                };

                await _unitOfWork.AnswerUserRepository.AddAsync(answerUser);
                await _unitOfWork.SaveAsync();

                TempData["success"] = "You Successfully created a quote";

                return RedirectToAction(nameof(Questions));
            }
            catch
            {
                TempData["error"] = "Can not create the quote";

                return View(form);
            }
        }
    }
}
