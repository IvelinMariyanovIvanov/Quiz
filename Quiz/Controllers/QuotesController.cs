using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Quiz.Data.Repositories.Interfaces;
using Quiz.Helpers;
using Quiz.Models.Entities;
using Quiz.Web.ViewModels;

namespace Quiz.Web.Controllers
{
    [Authorize(Roles = Constants.AdminRole)]
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
        public async Task<IActionResult> GetAllQuotesAPI()
        {
            List<Quote> quotes = 
                await _unitOfWork.QuoteRepository.GetAllAsync(includeTables: "Author");
           
            return Json(new { data = quotes });
        }

        public IActionResult Quotes()
        {
            return View();
        }

        public async Task<IActionResult> CreateQuote()
        {
            QuoteVM viewModel = new QuoteVM();

            await SetAuthorsDropDown(viewModel);

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateQuote(QuoteVM form)
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
                await SetAuthorsDropDown(form);

                return View(form);
            }
        }

        public async Task<IActionResult> EditQuote(int? id)
        {
            if (id == null | id == 0)
                return NotFound();

            Quote quote = await _unitOfWork.QuoteRepository.GetEntityAsync
                (i => i.Id == id, includeProperties: "Author");

            if (quote == null)
                return NotFound();

            // map entity to view model
            QuoteVM viewModel = _mapper.Map<QuoteVM>(quote);
            await SetAuthorsDropDown(viewModel);

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditQuote(QuoteVM form)
        {
            if (!ModelState.IsValid)
                return View(form);

            try
            {
                // map from view model to entity
                Quote entity = _mapper.Map<Quote>(form);

                _unitOfWork.QuoteRepository.Update(entity);
                await _unitOfWork.SaveAsync();

                TempData["success"] = $"You Successfully updated the quote with id {form.Id}";

                return RedirectToAction(nameof(Quotes));
            }
            catch
            {
                TempData["error"] = $"Can not update the quote with id {form.Id}";
                await SetAuthorsDropDown(form);

                return View(form);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteQuoteAPI(int? id)
        {
            Quote quote = await _unitOfWork.QuoteRepository.GetByIdAsync(id);

            if (quote == null)
                return Json(new { success = false, message = "Not found" });

            try
            {
                _unitOfWork.QuoteRepository.Delete(quote);
                await _unitOfWork.SaveAsync();
            }
            catch (Exception)
            {
                return Json(new { success = false, message = $"Can not delete the quote with id {quote.Id}" });
            }

            return Json(new { success = true, message = $"The quote with id {quote.Id} is deleted" });
        }

        /// <summary>
        /// Set Authors DropDown for QuoteVM
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [NonAction]
        private async Task SetAuthorsDropDown(QuoteVM viewModel)
        {
            List<Author> authors = await _unitOfWork.AuthorRepository.GetAllAsync();

            viewModel.AuthorsDropDown = authors
                .Select(a => new SelectListItem { Text = a.Name, Value = a.Id.ToString() });

            viewModel.AuthorsDropDown = viewModel.AuthorsDropDown.Prepend
                (new SelectListItem { Text = "-- Select an Author -- ", Value = 0.ToString() });
        }
    }
}
