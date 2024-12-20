using Guardadito.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Guardadito.Pages.Usuario;

public class DeleteModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public DeleteModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty] public Entity.Usuario Usuario { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(Guid? id)
    {
        if (id == null) return NotFound();

        var usuario = await _context.Usuarios.FirstOrDefaultAsync(m => m.Id == id);

        if (usuario is not null)
        {
            Usuario = usuario;

            return Page();
        }

        return NotFound();
    }

    public async Task<IActionResult> OnPostAsync(Guid? id)
    {
        if (id == null) return NotFound();

        var usuario = await _context.Usuarios.FindAsync(id);
        if (usuario != null)
        {
            Usuario = usuario;
            _context.Usuarios.Remove(Usuario);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}