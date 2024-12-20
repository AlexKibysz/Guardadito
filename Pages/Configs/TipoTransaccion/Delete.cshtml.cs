using Guardadito.Data;
using Guardadito.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Guardadito.Pages.Config.TipoTransaccion;

public class DeleteModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public DeleteModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty] public TransactionType TransactionType { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(Guid? id)
    {
        if (id == null) return NotFound();

        var transactiontype = await _context.TransactionType.FirstOrDefaultAsync(m => m.Id == id);

        if (transactiontype is not null)
        {
            TransactionType = transactiontype;

            return Page();
        }

        return NotFound();
    }

    public async Task<IActionResult> OnPostAsync(Guid? id)
    {
        if (id == null) return NotFound();

        var transactiontype = await _context.TransactionType.FindAsync(id);
        if (transactiontype != null)
        {
            TransactionType = transactiontype;
            _context.TransactionType.Remove(TransactionType);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}