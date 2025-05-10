using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SupermarketWEB.Models;

namespace SupermarketWEB.Pages.Products
{
    public class EditModel : PageModel
    {
        private readonly SupermarketWEB.Data.SupermarketContext _context;

        public EditModel(SupermarketWEB.Data.SupermarketContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Product Product { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) return NotFound();

            var product = await _context.Products.FindAsync(id);
            if (product == null) return NotFound();

            Product = product;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            _context.Attach(Product).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
