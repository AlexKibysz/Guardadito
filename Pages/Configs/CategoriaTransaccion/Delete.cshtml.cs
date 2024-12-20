using Guardadito.Data;
using Guardadito.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Guardadito.Pages.Config.CategoriaTransaccion;

public class DeleteModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public DeleteModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty] public TransactionCategory TransactionCategory { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(Guid? id)
    {
        if (id == null) return NotFound();

        var transactioncategory = await _context.TransactionCategory.FirstOrDefaultAsync(m => m.Id == id);

        if (transactioncategory is not null)
        {
            TransactionCategory = transactioncategory;

            return Page();
        }

        return NotFound();
    }

    public async Task<IActionResult> OnPostAsync(Guid? id)
    {
        if (id == null) return NotFound();

        var transactioncategory = await _context.TransactionCategory.FindAsync(id);
        if (transactioncategory != null)
        {
            TransactionCategory = transactioncategory;
            _context.TransactionCategory.Remove(TransactionCategory);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}