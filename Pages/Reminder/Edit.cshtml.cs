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

namespace Guardadito.Pages.Reminder
{
    public class EditModel : PageModel
    {
        private readonly Guardadito.Data.ApplicationDbContext _context;

        public EditModel(Guardadito.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Recordatorio Recordatorio { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recordatorio =  await _context.Recordatorios.FirstOrDefaultAsync(m => m.Id == id);
            if (recordatorio == null)
            {
                return NotFound();
            }
            Recordatorio = recordatorio;
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

            _context.Attach(Recordatorio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecordatorioExists(Recordatorio.Id))
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

        private bool RecordatorioExists(Guid id)
        {
            return _context.Recordatorios.Any(e => e.Id == id);
        }
    }
}
