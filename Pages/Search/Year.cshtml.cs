using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Books.Pages.Search
{
    public class YearModel : PageModel
    {
        DataContextDapper _dapper;

        public List<Book> BooksList = new List<Book>();

        public string _errorMessage = "";

        public YearModel(IConfiguration config)
        {
            _dapper = new DataContextDapper(config);
        }

        public void OnGet() { }

        public void OnPost(string BookYear)
        {
            Console.WriteLine(BookYear);

            string sql = @"SELECT * FROM ourhome.books WHERE Year = "+ BookYear +";";

            BooksList = _dapper.LoadData2<Book>(sql);

            if (BooksList.Count == 0)
            {
                _errorMessage = "No Data! Error!";
            }
        }
    }
}
