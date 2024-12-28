using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Guardadito.Data;
using Guardadito.Entity;

namespace Guardadito.Pages.Transaction
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
        ViewData["CategoriaId"] = new SelectList(_context.Categorias, "Id", "Color");
        ViewData["CuentaId"] = new SelectList(_context.Cuentas, "Id", "Nombre");
        ViewData["MonedaDestinoId"] = new SelectList(_context.Currencies, "Id", "Code");
        ViewData["MonedaOriginalId"] = new SelectList(_context.Currencies, "Id", "Code");
        ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Email");
            return Page();
        }

        [BindProperty]
        public Transaccion Transaccion { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Transacciones.Add(Transaccion);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
