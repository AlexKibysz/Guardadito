using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Guardadito.Data;
using Guardadito.Entity;

namespace Guardadito.Pages.StatsDetail
{
    public class DeleteModel : PageModel
    {
        private readonly Guardadito.Data.ApplicationDbContext _context;

        public DeleteModel(Guardadito.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public EstadisticaDetalle EstadisticaDetalle { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadisticadetalle = await _context.EstadisticasDetalle.FirstOrDefaultAsync(m => m.Id == id);

            if (estadisticadetalle is not null)
            {
                EstadisticaDetalle = estadisticadetalle;

                return Page();
            }

            return NotFound();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadisticadetalle = await _context.EstadisticasDetalle.FindAsync(id);
            if (estadisticadetalle != null)
            {
                EstadisticaDetalle = estadisticadetalle;
                _context.EstadisticasDetalle.Remove(EstadisticaDetalle);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
