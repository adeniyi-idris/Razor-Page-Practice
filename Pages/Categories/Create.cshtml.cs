using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication2.Data;
using WebApplication2.Model;

namespace WebApplication2.Pages.Categories
{
    public class CreateModel : PageModel
    {
        private readonly DataContext _db;
        [BindProperty]
        public Category Category {  get; set; }
        public CreateModel(DataContext db)
        {
            _db = db;
        }
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if (Category.Name == Category.DisplayOrder.ToString())
            {
                ModelState.AddModelError(string.Empty, "The Display Order cannot exactly match the Name.");
            }
            if (ModelState.IsValid)
            {
                await _db.categories.AddAsync(Category);
                await _db.SaveChangesAsync();
                TempData["success"] = "Category created successfully";
                return RedirectToPage("Index");
            }
            return Page();
           
        }
    }
}
