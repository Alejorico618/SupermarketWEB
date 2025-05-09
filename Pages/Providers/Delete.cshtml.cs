using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SupermarketWEB.Models;

namespace SupermarketWEB.Pages.Providers
{
    public class DeleteModel : PageModel
    {
        private readonly SupermarketWEB.Data.SupermarketContext _context;

        public DeleteModel(SupermarketWEB.Data.SupermarketContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Provider Provider { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) return NotFound();

            Provider = await _context.Providers.FindAsync(id);

            if (Provider == null) return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null) return NotFound();

            var provider = await _context.Providers.FindAsync(id);

            if (provider != null)
            {
                _context.Providers.Remove(provider);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
