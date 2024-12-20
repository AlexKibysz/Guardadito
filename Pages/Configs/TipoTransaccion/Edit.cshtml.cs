using Guardadito.Data;
using Guardadito.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Guardadito.Pages.Config.TipoTransaccion;

public class EditModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public EditModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty] public TransactionType TransactionType { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(Guid? id)
    {
        if (id == null) return NotFound();

        var transactiontype = await _context.TransactionType.FirstOrDefaultAsync(m => m.Id == id);
        if (transactiontype == null) return NotFound();
        TransactionType = transactiontype;
        return Page();
    }

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more information, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        _context.Attach(TransactionType).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TransactionTypeExists(TransactionType.Id)) return NotFound();

            throw;
        }

        return RedirectToPage("./Index");
    }

    private bool TransactionTypeExists(Guid id)
    {
        return _context.TransactionType.Any(e => e.Id == id);
    }
}