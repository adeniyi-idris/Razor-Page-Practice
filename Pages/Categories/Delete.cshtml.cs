using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication2.Data;
using WebApplication2.Model;

namespace WebApplication2.Pages.Categories
{
    public class DeleteModel : PageModel
    {
        private readonly DataContext _db;
        [BindProperty]
        public Category Category { get; set; }
        public DeleteModel(DataContext db)
        {
            _db = db;
        }
        public void OnGet(int id)
        {
            Category = _db.categories.FirstOrDefault(c => c.CategoryId == id);
        }

        public async Task<IActionResult> OnPost()
        {
                var categoryFromDb = _db.categories.Find(Category.CategoryId);
                if(categoryFromDb != null)
                {
                    _db.categories.Remove(categoryFromDb);
                    await _db.SaveChangesAsync();
                TempData["success"] = "Category deleted successfully";
                return RedirectToPage("Index");
                }
            return Page();
        }
    }
}
