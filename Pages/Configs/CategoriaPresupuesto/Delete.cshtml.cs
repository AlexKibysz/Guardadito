using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Guardadito.Data;
using Guardadito.Entity;

namespace Guardadito.Pages.CategoriaPresupuesto
{
   public class DeleteModel : PageModel
   {
      private readonly Guardadito.Data.ApplicationDbContext _context;

      public DeleteModel(Guardadito.Data.ApplicationDbContext context)
      {
         _context = context;
      }

      [BindProperty]
      public Entity.CategoriaPresupuesto CategoriaPresupuesto { get; set; } = default!;

      public async Task<IActionResult> OnGetAsync(Guid? id)
      {
         if (id == null)
         {
            return NotFound();
         }

         var categoriapresupuesto = await _context.CategoriasPresupuesto.FirstOrDefaultAsync(m => m.Id == id);

         if (categoriapresupuesto is not null)
         {
            CategoriaPresupuesto = categoriapresupuesto;

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

         var categoriapresupuesto = await _context.CategoriasPresupuesto.FindAsync(id);
         if (categoriapresupuesto != null)
         {
            CategoriaPresupuesto = categoriapresupuesto;
            _context.CategoriasPresupuesto.Remove(CategoriaPresupuesto);
            await _context.SaveChangesAsync();
         }

         return RedirectToPage("./Index");
      }
   }
}
