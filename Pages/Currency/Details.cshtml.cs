using Guardadito.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Guardadito.Pages.Currency;

public class Details : PageModel
{
   private readonly ApplicationDbContext _context;
   private readonly ILogger<Details> _logger;

   public Details(ApplicationDbContext context, ILogger<Details> logger)
   {
      _context = context;
      _logger = logger;
   }

   public Entity.Currency Currency { get; set; }

   public async Task<IActionResult> OnGetAsync(Guid? id)
   {
      if (id == null)
      {
         return NotFound();
      }

      try
      {
         Currency = await _context.Currencies
             .AsNoTracking()
             .FirstOrDefaultAsync(m => m.Id == id);

         if (Currency == null)
         {
            return NotFound();
         }

         return Page();
      }
      catch (Exception ex)
      {
         _logger.LogError(ex, "Error al cargar los detalles de la moneda");
         TempData["ErrorMessage"] = "Ha ocurrido un error al cargar los detalles de la moneda.";
         return RedirectToPage("./Index");
      }
   }
}