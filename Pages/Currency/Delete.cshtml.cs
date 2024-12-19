using Guardadito.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Guardadito.Pages.Currency;

public class Delete : PageModel
{
   private readonly ApplicationDbContext _context;
   private readonly ILogger<Delete> _logger;

   public Delete(ApplicationDbContext context, ILogger<Delete> logger)
   {
      _context = context;
      _logger = logger;
   }

   [BindProperty]
   public Entity.Currency Currency { get; set; }

   public async Task<IActionResult> OnGetAsync(Guid? id)
   {
      if (id == null)
      {
         return NotFound();
      }

      Currency = await _context.Currencies.FirstOrDefaultAsync(m => m.Id == id);

      if (Currency == null)
      {
         return NotFound();
      }

      return Page();
   }

   public async Task<IActionResult> OnPostAsync()
   {
      try
      {
         var currency = await _context.Currencies.FindAsync(Currency.Id);

         if (currency == null)
         {
            return NotFound();
         }

         _context.Currencies.Remove(currency);
         await _context.SaveChangesAsync();

         TempData["SuccessMessage"] = "La moneda se eliminó correctamente.";
         return RedirectToPage("./Index");
      }
      catch (Exception ex)
      {
         _logger.LogError(ex, "Error al eliminar la moneda");
         TempData["ErrorMessage"] = "Ocurrió un error al eliminar la moneda.";
         return RedirectToPage("./Index");
      }
   }
}