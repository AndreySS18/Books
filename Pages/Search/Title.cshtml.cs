using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Books.Pages.Search
{
    public class TitleModel : PageModel
    {
        DataContextDapper _dapper;

        public List<Book> BooksList = new List<Book>();

        public string _errorMessage = "";

        public TitleModel(IConfiguration config)
        {
            _dapper = new DataContextDapper(config);
        }

        public void OnGet() { }

        public void OnPost(string BookTitle)
        {
            Console.WriteLine(BookTitle);

            string sql = $"Call GetBooksByTitle('{BookTitle}');";

            BooksList = _dapper.LoadData2<Book>(sql);

            if (BooksList.Count == 0)
            {
                _errorMessage = "No Data! Error!";
            }
        }
    }
}
