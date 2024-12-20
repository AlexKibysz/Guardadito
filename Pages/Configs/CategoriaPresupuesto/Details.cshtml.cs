using Guardadito.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Guardadito.Pages.CategoriaPresupuesto;

public class DetailsModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public DetailsModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public Entity.CategoriaPresupuesto CategoriaPresupuesto { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(Guid? id)
    {
        if (id == null) return NotFound();

        var categoriapresupuesto = await _context.CategoriasPresupuesto.FirstOrDefaultAsync(m => m.Id == id);

        if (categoriapresupuesto is not null)
        {
            CategoriaPresupuesto = categoriapresupuesto;

            return Page();
        }

        return NotFound();
    }
}