using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Books.Pages.Search
{
    public class PublisingModel : PageModel
    {
        DataContextDapper _dapper;

        public List<Book> BooksList = new List<Book>();

        public string _errorMessage = "";

        public PublisingModel(IConfiguration config)
        {
            _dapper = new DataContextDapper(config);
        }

        public void OnGet() { }

        public void OnPost(string BookPublishing)
        {
            Console.WriteLine(BookPublishing);

            string sql = @"SELECT * FROM ourhome.books WHERE Year = " + BookPublishing + ";";

            BooksList = _dapper.LoadData2<Book>(sql);

            if (BooksList.Count == 0)
            {
                _errorMessage = "No Data! Error!";
            }
        }
    }
}
