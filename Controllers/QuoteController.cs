using Microsoft.AspNetCore.Mvc;
using QuoteApp.Models;

namespace QuoteApp.Controllers 
{
    public class QuoteController : Controller
    {
        private QuoteRepository _repository = new QuoteRepository();

        public IActionResult Index()
        {
            var quotes = _repository.GetAll();
            return View(quotes);
        }

        [HttpPost]
        public IActionResult Add(string text, string author)
        {
            if (!string.IsNullOrEmpty(text) && !string.IsNullOrEmpty(author))
            {
	      var newQuote = new Quote { Text = text, Author = author }; 
              _repository.Add(newQuote);

              //return Partial("_QuoteItem", newQuote);
	      return PartialView("_QuoteItem", newQuote);
            }
            //return RedirectToAction("Index"); // Refresh the page after adding
	    //return Partial("_QuoteList", _repository.GetAll());
	    return BadRequest();
        }
    }
}
