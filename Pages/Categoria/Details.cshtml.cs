using Guardadito.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Guardadito.Pages.Categoria;

public class DetailsModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public DetailsModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public Entity.Categoria Categoria { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(Guid? id)
    {
        if (id == null) return NotFound();

        var categoria = await _context.Categorias.FirstOrDefaultAsync(m => m.Id == id);

        if (categoria is not null)
        {
            Categoria = categoria;

            return Page();
        }

        return NotFound();
    }
}