using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Books.Pages.Search
{
    public class AuthorModel : PageModel
    {
        DataContextDapper _dapper;

        public List<Book> BooksList = new List<Book>();

        public string _errorMessage = "";

        public AuthorModel(IConfiguration config)
        {
            _dapper = new DataContextDapper(config);
        }

        public void OnGet() { }

        public void OnPost(string BookAuthor)
        {
            Console.WriteLine(BookAuthor);

            string sql = @"SELECT * FROM ourhome.books WHERE Year = " + BookAuthor + ";";

            BooksList = _dapper.LoadData2<Book>(sql);

            if (BooksList.Count == 0)
            {
                _errorMessage = "No Data! Error!";
            }
        }
    }
}
