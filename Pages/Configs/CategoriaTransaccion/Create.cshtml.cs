using Guardadito.Data;
using Guardadito.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Guardadito.Pages.Config.CategoriaTransaccion;

public class CreateModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public CreateModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty] public TransactionCategory TransactionCategory { get; set; } = default!;

    public IActionResult OnGet()
    {
        return Page();
    }

    // For more information, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        _context.TransactionCategory.Add(TransactionCategory);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}