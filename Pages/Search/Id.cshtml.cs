using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Books.Pages.Search
{
    public class IdModel : PageModel
    {
        DataContextDapper _dapper;

        public Book Books = new Book();

        public string _errorMessage = "";

        public IdModel(IConfiguration config)
        {
            _dapper = new DataContextDapper(config);
        }

        public void OnGet() { }

        public void OnPost(int? BookId)
        {
            Console.WriteLine(BookId);

            string sql = @"SELECT * FROM ourhome.books WHERE Year = " + BookId + ";";

            if (_dapper.LoadDataSingle<Book>(sql) == null)
            {
                _errorMessage = "No Data! Error!";
                return;
            }

            Books = _dapper.LoadDataSingle<Book>(sql);
        }
    }
}
