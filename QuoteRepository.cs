using QuoteApp.Models;

namespace QuoteApp
{
    public class QuoteRepository
    {
        private static List<Quote> _quotes = new List<Quote>()
        {
            new Quote { Id = 1, Text = "There is no try.  Do or do not.", Author = "Yoda" },
            new Quote { Id = 2, Text = "Strive not to be a success, but rather to be of value.", Author = "Albert Einstein" }
        };

        public List<Quote> GetAll()
        {
            return _quotes;
        }

        public void Add(Quote quote)
        {
            // Simple ID generation (in real app, use database ID generation)
            quote.Id = _quotes.Any() ? _quotes.Max(q => q.Id) + 1 : 1; 
            _quotes.Add(quote);
        }
    }
}
