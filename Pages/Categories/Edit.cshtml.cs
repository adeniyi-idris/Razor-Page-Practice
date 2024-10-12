using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication2.Data;
using WebApplication2.Model;

namespace WebApplication2.Pages.Categories
{
    public class EditModel : PageModel
    {
        private readonly DataContext _db;
        [BindProperty]
        public Category Category { get; set; }
        public EditModel(DataContext db)
        {
            _db = db;
        }

        public void OnGet(int id)
        {
            Category = _db.categories.FirstOrDefault(c => c.CategoryId == id);
            //
            //Category = _db.categories.Find(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (Category.Name == Category.DisplayOrder.ToString())
            {
                ModelState.AddModelError(string.Empty, "The Display Order cannot exactly match the Name.");
            }
            if (ModelState.IsValid)
            {
                 _db.categories.Update(Category);
                await _db.SaveChangesAsync();
                TempData["success"] = "Category updated successfully";
                return RedirectToPage("Index");
            }
            return Page();

        }
    }
}
