using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SupermarketWEB.Models;

namespace SupermarketWEB.Pages.PayModes
{
    public class CreateModel : PageModel
    {
        private readonly SupermarketWEB.Data.SupermarketContext _context;

        public CreateModel(SupermarketWEB.Data.SupermarketContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PayMode PayMode { get; set; }

        public IActionResult OnGet() => Page();

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || PayMode == null)
                return Page();

            _context.PayModes.Add(PayMode);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
