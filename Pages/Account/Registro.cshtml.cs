using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SupermarketWEB.Models;
using SupermarketWEB.Data;
using Autenticacion.Models;
using Microsoft.EntityFrameworkCore;

namespace SupermarketWEB.Pages.Account
{
    public class RegistroModel : PageModel
    {
        private readonly SupermarketContext _context;

        public RegistroModel(SupermarketContext context)
        {
            _context = context;
        }

        [BindProperty]
        public User User { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var existe = await _context.Users
                .AnyAsync(u => u.Email == User.Email);

            if (existe)
            {
                ModelState.AddModelError("User.Email", "El correo ya está registrado.");
                return Page();
            }

            _context.Users.Add(User);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Account/Login");
        }
    }
}
