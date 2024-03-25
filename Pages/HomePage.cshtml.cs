using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Books.Pages
{
    public class HomePageModel : PageModel
    {
        DataContextDapper _dapper;
        public HomePageModel(IConfiguration config)
        {
            _dapper = new DataContextDapper(config);
        }
        public IEnumerable<Book> Books;
        public void OnGet()
        {
            try
            {
                string sql = @"select * from books";
                Books = _dapper.LoadData<Book>(sql);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString);
            }
        }
    }
}
