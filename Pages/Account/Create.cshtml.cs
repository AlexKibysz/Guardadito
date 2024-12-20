using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Guardadito.Data;
using Guardadito.Entity;

namespace Guardadito.Pages.Account
{
    public class CreateModel : PageModel
    {
        private readonly Guardadito.Data.ApplicationDbContext _context;

        public CreateModel(Guardadito.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["MonedaPrincipalId"] = new SelectList(_context.Currencies, "Id", "Code");
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Email");
            ViewData["TipoCuenta"] = new SelectList(_context.AccountType, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Cuenta Cuenta { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Cuentas.Add(Cuenta);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
