using Guardadito.Data;
using Guardadito.Entity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Guardadito.Pages.Config.CategoriaTransaccion;

public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public IndexModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public IList<TransactionCategory> TransactionCategory { get; set; } = default!;

    public async Task OnGetAsync()
    {
        TransactionCategory = await _context.TransactionCategory.ToListAsync();
    }
}