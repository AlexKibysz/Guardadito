using Guardadito.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Guardadito.Pages.Categoria;

public class DeleteModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public DeleteModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty] public Entity.Categoria Categoria { get; set; } = default!;

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

    public async Task<IActionResult> OnPostAsync(Guid? id)
    {
        if (id == null) return NotFound();

        var categoria = await _context.Categorias.FindAsync(id);
        if (categoria != null)
        {
            Categoria = categoria;
            _context.Categorias.Remove(Categoria);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}