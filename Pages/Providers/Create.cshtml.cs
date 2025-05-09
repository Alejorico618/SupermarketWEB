using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SupermarketWEB.Models;

namespace SupermarketWEB.Pages.Providers
{
    public class CreateModel : PageModel
    {
        private readonly SupermarketWEB.Data.SupermarketContext _context;

        public CreateModel(SupermarketWEB.Data.SupermarketContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Provider Provider { get; set; }

        public IActionResult OnGet() => Page();

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || Provider == null)
                return Page();

            _context.Providers.Add(Provider);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
