using Guardadito.Data;
using Guardadito.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Guardadito.Pages.Config.TipoCuenta;

public class DetailsModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public DetailsModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public AccountType AccountType { get; set; } = default!;

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
}