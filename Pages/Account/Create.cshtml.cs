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
        private readonly ILogger<CreateModel> _logger;

        public CreateModel(Guardadito.Data.ApplicationDbContext context, ILogger<CreateModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult OnGet()
        {
            // Load data
            var accountTypes = _context.AccountType.ToList();
            var currencies = _context.Currencies.ToList();
            var usuarios = _context.Usuarios.ToList();

            // Log counts for debugging
            _logger.LogInformation($"AccountTypes: {accountTypes.Count}");
            _logger.LogInformation($"Currencies: {currencies.Count}");
            _logger.LogInformation($"Usuarios: {usuarios.Count}");

            // Fix: Change ViewData key to match what's used in the view
            ViewData["TipoCuentaId"] = new SelectList(accountTypes, "Id", "Name");
            ViewData["MonedaPrincipalId"] = new SelectList(currencies, "Id", "Code");
            ViewData["UsuarioId"] = new SelectList(usuarios, "Id", "Nombre");
            return Page();
        }

        [BindProperty]
        public Cuenta Cuenta { get; set; } = default!;

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
