using Guardadito.Data;
using Guardadito.Entity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Guardadito.Pages.Account;

public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public IndexModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public IList<Cuenta> Cuenta { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Cuenta = await _context.Cuentas
            .Include(c => c.MonedaPrincipal)
            .Include(c => c.Usuario).ToListAsync();
    }
}