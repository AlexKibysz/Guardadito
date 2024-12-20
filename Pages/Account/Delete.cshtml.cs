using Guardadito.Data;
using Guardadito.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Guardadito.Pages.Account;

public class DeleteModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public DeleteModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty] public Cuenta Cuenta { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(Guid? id)
    {
        if (id == null) return NotFound();

        var cuenta = await _context.Cuentas.FirstOrDefaultAsync(m => m.Id == id);

        if (cuenta is not null)
        {
            Cuenta = cuenta;

            return Page();
        }

        return NotFound();
    }

    public async Task<IActionResult> OnPostAsync(Guid? id)
    {
        if (id == null) return NotFound();

        var cuenta = await _context.Cuentas.FindAsync(id);
        if (cuenta != null)
        {
            Cuenta = cuenta;
            _context.Cuentas.Remove(Cuenta);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}