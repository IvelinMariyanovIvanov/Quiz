using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Quiz.Data.Repositories.Interfaces;
using Quiz.Models.Entities;

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

            return Json(new { data = quotes });
        }

        public IActionResult Quotes()
        {
            return View();
        }
    }
}
