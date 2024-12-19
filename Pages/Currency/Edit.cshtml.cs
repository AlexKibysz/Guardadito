using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Guardadito.Data;

namespace Guardadito.Pages.Currency;

public class Edit : PageModel
{
   private readonly ApplicationDbContext _context;
   private readonly ILogger<Edit> _logger;

   public Edit(ApplicationDbContext context, ILogger<Edit> logger)
   {
      _context = context;
      _logger = logger;
   }

   [BindProperty]
   public CurrencyEditModel CurrencyModel { get; set; }

   public class CurrencyEditModel
   {
      public Guid Id { get; set; }

      [Required(ErrorMessage = "El código es obligatorio")]
      public string Code { get; set; }

      [Required(ErrorMessage = "El nombre es obligatorio")]
      public string Name { get; set; }

      [Required(ErrorMessage = "El símbolo es obligatorio")]
      public string Symbol { get; set; }

      [Required(ErrorMessage = "El tipo de cambio es obligatorio")]
      public decimal ExchangeRate { get; set; }

      [Required(ErrorMessage = "La fecha es obligatoria")]
      public DateOnly RateDate { get; set; }

      public bool IsActive { get; set; }
   }

   public async Task<IActionResult> OnGetAsync(Guid id)
   {
      var currency = await _context.Currencies.FindAsync(id);

      if (currency == null)
      {
         return NotFound();
      }

      CurrencyModel = new CurrencyEditModel
      {
         Id = currency.Id,
         Code = currency.Code,
         Name = currency.Name,
         Symbol = currency.Symbol,
         ExchangeRate = currency.ExchangeRate,
         RateDate = currency.RateDate,
         IsActive = currency.IsActive
      };

      return Page();
   }

   public async Task<IActionResult> OnPostAsync()
   {
      if (!ModelState.IsValid)
         return Page();

      try
      {
         var currency = await _context.Currencies.FindAsync(CurrencyModel.Id);

         if (currency == null)
         {
            return NotFound();
         }

         currency.Code = CurrencyModel.Code.ToUpper();
         currency.Name = CurrencyModel.Name;
         currency.Symbol = CurrencyModel.Symbol;
         currency.ExchangeRate = CurrencyModel.ExchangeRate;
         currency.RateDate = CurrencyModel.RateDate;
         currency.IsActive = CurrencyModel.IsActive;

         currency.SetAuditDates(isNew: false);

         await _context.SaveChangesAsync();
         return RedirectToPage("./Index");
      }
      catch (Exception ex)
      {
         _logger.LogError(ex, "Error al actualizar la moneda");
         ModelState.AddModelError(string.Empty, "Ha ocurrido un error al actualizar la moneda.");
         return Page();
      }
   }
}