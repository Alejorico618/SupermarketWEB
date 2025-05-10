using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SupermarketWEB.Models;

namespace SupermarketWEB.Pages.Products
{
    public class CreateModel : PageModel
    {
        private readonly SupermarketWEB.Data.SupermarketContext _context;

        public CreateModel(SupermarketWEB.Data.SupermarketContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Product Product { get; set; }

        public IActionResult OnGet() => Page();

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || Product == null)
                return Page();

            _context.Products.Add(Product);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
