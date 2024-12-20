using Guardadito.Data;
using Guardadito.Entity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Guardadito.Pages.Config.TipoTransaccion;

public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public IndexModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public IList<TransactionType> TransactionType { get; set; } = default!;

    public async Task OnGetAsync()
    {
        TransactionType = await _context.TransactionType.ToListAsync();
    }
}