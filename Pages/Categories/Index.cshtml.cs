using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication2.Data;
using WebApplication2.Model;

namespace WebApplication2.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly DataContext _db;

        public List<Category> Categories { get; set; }
        public IndexModel(DataContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
            Categories = _db.categories.ToList();
        }
    }
}
