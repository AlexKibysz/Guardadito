using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Guardadito.Data;
using Guardadito.Entity;

namespace Guardadito.Pages.CategoriaPresupuesto
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
         ViewData["PresupuestoId"] = new SelectList(_context.Presupuestos, "Id", "Nombre");
         return Page();
      }

      [BindProperty]
      public Entity.CategoriaPresupuesto CategoriaPresupuesto { get; set; } = default!;

      // For more information, see https://aka.ms/RazorPagesCRUD.
      public async Task<IActionResult> OnPostAsync()
      {
         if (!ModelState.IsValid)
         {
            return Page();
         }

         _context.CategoriasPresupuesto.Add(CategoriaPresupuesto);
         await _context.SaveChangesAsync();

         return RedirectToPage("./Index");
      }
   }
}
