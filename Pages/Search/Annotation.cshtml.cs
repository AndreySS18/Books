using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Books.Pages.Search
{
    public class AnnotationModel : PageModel
    {
            DataContextDapper _dapper;

            public List<Book> BooksList = new List<Book>();

            public string _errorMessage = "";

            public AnnotationModel(IConfiguration config)
            {
                _dapper = new DataContextDapper(config);
            }

            public void OnGet() { }

            public void OnPost(string BookAnnotation)
            {
                Console.WriteLine(BookAnnotation);

                string sql = @"SELECT * FROM books WHERE MATCH (Annotation) AGAINST ('" + BookAnnotation + "' IN BOOLEAN MODE);";

                BooksList = _dapper.LoadData2<Book>(sql);

                if (BooksList.Count == 0)
                {
                    _errorMessage = "No Data! Error!";
                }
            }
    }
}
