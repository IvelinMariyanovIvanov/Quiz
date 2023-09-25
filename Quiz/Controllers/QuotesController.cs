using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Quiz.Data.Repositories.Interfaces;
using Quiz.Models.Entities;
using Quiz.Web.ViewModels;

namespace Quiz.Web.Controllers
{
    public class QuotesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public QuotesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllQuatesApi()
        {
            List<Quote> quotes = 
                await _unitOfWork.QuoteRepository.GetAllAsync(includeTables: "Author");

            return Json(new { data = quotes });
        }

        public async Task<IActionResult> Quotes()
        {
            return View();
        }

        public async Task<IActionResult> CreateQuote()
        {
            CreateQuoteVM viewModel = new CreateQuoteVM();

            await CreateQuoteViewModel(viewModel);

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateQuote(CreateQuoteVM form)
        {
            if (!ModelState.IsValid)
                return View(form);

            try
            {
                // map from view model to entity
                Quote entity = _mapper.Map<Quote>(form);
 
                await _unitOfWork.QuoteRepository.AddAsync(entity);
                await _unitOfWork.SaveAsync();

                TempData["success"] = "You Successfully created a quote";

                return RedirectToAction(nameof(Quotes));              
            }
            catch
            {
                TempData["error"] = "Can not create the quote";

                // populate authors dropdown
                await CreateQuoteViewModel(form);

                return View(form);
            }
        }

        public async Task<IActionResult> Details(int id)
        {
            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult>  Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [NonAction]
        private async Task CreateQuoteViewModel(CreateQuoteVM viewModel)
        {
            List<Author> authors = await _unitOfWork.AuthorRepository.GetAllAsync();

            viewModel.AuthorsDropDown = authors
                .Select(a => new SelectListItem { Text = a.Name, Value = a.Id.ToString() });
            viewModel.AuthorsDropDown = viewModel.AuthorsDropDown.Prepend(new SelectListItem
            { Text = "-- Select an Author -- ", Value = 0.ToString() });
        }
    }
}
