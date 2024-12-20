using Guardadito.Data;
using Guardadito.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Guardadito.Pages.Config.TipoCuenta;

public class DeleteModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public DeleteModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty] public AccountType AccountType { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(Guid? id)
    {
        if (id == null) return NotFound();

        var accounttype = await _context.AccountType.FirstOrDefaultAsync(m => m.Id == id);

        if (accounttype is not null)
        {
            AccountType = accounttype;

            return Page();
        }

        return NotFound();
    }

    public async Task<IActionResult> OnPostAsync(Guid? id)
    {
        if (id == null) return NotFound();

        var accounttype = await _context.AccountType.FindAsync(id);
        if (accounttype != null)
        {
            AccountType = accounttype;
            _context.AccountType.Remove(AccountType);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}