using System.ComponentModel.DataAnnotations;
using Guardadito.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Guardadito.Pages.Currency;

public class Create : PageModel
{
    private readonly ApplicationDbContext _context;

    public Create(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty] public CurrencyCreateModel CurrencyModel { get; set; }

    public IActionResult OnGet()
    {
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
            return Page();

        var currency = new Entity.Currency
        {
            Code = CurrencyModel.Code.ToUpper(),
            Name = CurrencyModel.Name,
            Symbol = CurrencyModel.Symbol,
            ExchangeRate = CurrencyModel.ExchangeRate,
            RateDate = CurrencyModel.RateDate,
            IsActive = CurrencyModel.IsActive
        };

        currency.SetAuditDates(true);

        await _context.Currencies.AddAsync(currency);
        await _context.SaveChangesAsync();

        return RedirectToPage("Index");
    }

    public class CurrencyCreateModel
    {
        [Required(ErrorMessage = "El código es obligatorio")]
        public string Code { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El símbolo es obligatorio")]
        public string Symbol { get; set; }

        [Required(ErrorMessage = "El tipo de cambio es obligatorio")]
        public decimal ExchangeRate { get; set; }

        [Required(ErrorMessage = "La fecha es obligatoria")]
        public DateOnly RateDate { get; set; } = DateOnly.FromDateTime(DateTime.Today);

        public bool IsActive { get; set; } = true;
    }
}