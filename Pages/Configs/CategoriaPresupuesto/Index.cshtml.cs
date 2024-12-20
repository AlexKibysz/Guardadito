using Guardadito.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Guardadito.Pages.CategoriaPresupuesto;

public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public IndexModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public IList<Entity.CategoriaPresupuesto> CategoriaPresupuesto { get; set; } = default!;

    public async Task OnGetAsync()
    {
        CategoriaPresupuesto = await _context.CategoriasPresupuesto
            .Include(c => c.Presupuesto).ToListAsync();
    }
}