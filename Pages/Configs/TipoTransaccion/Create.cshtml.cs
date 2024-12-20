using Guardadito.Data;
using Guardadito.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Guardadito.Pages.Config.TipoTransaccion;

public class CreateModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public CreateModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty] public TransactionType TransactionType { get; set; } = default!;

    public IActionResult OnGet()
    {
        return Page();
    }

    // For more information, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        _context.TransactionType.Add(TransactionType);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}