using Guardadito.Data;
using Guardadito.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Guardadito.Pages.Config.TipoCuenta;

public class CreateModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public CreateModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty] public AccountType AccountType { get; set; } = default!;

    public IActionResult OnGet()
    {
        return Page();
    }

    // For more information, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        _context.AccountType.Add(AccountType);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}