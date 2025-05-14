using Autenticacion.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SupermarketWEB.Data;
using SupermarketWEB.Models;
using System.Security.Claims;

namespace SupermarketWEB.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly SupermarketContext _context;

        public LoginModel(SupermarketContext context)
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
            if (!ModelState.IsValid) return Page();

            var userInDb = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == User.Email && u.Password == User.Password);

            if (userInDb != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, userInDb.Email),
                    new Claim(ClaimTypes.Email, userInDb.Email)
                };

                var identity = new ClaimsIdentity(claims, "MyCookieAuth");
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync("MyCookieAuth", principal);
                return RedirectToPage("/Index");
            }

            ModelState.AddModelError(string.Empty, "Credenciales incorrectas");
            return Page();
        }
    }
}
