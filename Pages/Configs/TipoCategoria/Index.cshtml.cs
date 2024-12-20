using Guardadito.Data;
using Guardadito.Entity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Guardadito.Pages.Config.TipoCategoria;

public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public IndexModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public IList<CategoryType> CategoryType { get; set; } = default!;

    public async Task OnGetAsync()
    {
        CategoryType = await _context.CategoryType.ToListAsync();
    }
}