using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Guardadito.Data;
using Guardadito.Entity;

namespace Guardadito.Pages.Transaction
{
    public class EditModel : PageModel
    {
        private readonly Guardadito.Data.ApplicationDbContext _context;

        public EditModel(Guardadito.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Transaccion Transaccion { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaccion =  await _context.Transacciones.FirstOrDefaultAsync(m => m.Id == id);
            if (transaccion == null)
            {
                return NotFound();
            }
            Transaccion = transaccion;
           ViewData["CategoriaId"] = new SelectList(_context.Categorias, "Id", "Color");
           ViewData["CuentaId"] = new SelectList(_context.Cuentas, "Id", "Nombre");
           ViewData["MonedaDestinoId"] = new SelectList(_context.Currencies, "Id", "Code");
           ViewData["MonedaOriginalId"] = new SelectList(_context.Currencies, "Id", "Code");
           ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Email");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Transaccion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransaccionExists(Transaccion.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TransaccionExists(Guid id)
        {
            return _context.Transacciones.Any(e => e.Id == id);
        }
    }
}
