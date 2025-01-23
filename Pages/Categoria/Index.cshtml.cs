using Guardadito.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Guardadito.Pages.Categoria;

public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public IndexModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public IList<Entity.Categoria> Categoria { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Categoria = await _context.Categorias
            .Include(c => c.CategoriaPadre)
            .Include(c => c.TipoCategoria)
            .OrderBy(c => c.Nombre)
            .ToListAsync();
    }
}