using Guardadito.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Guardadito.Pages.Usuario;

public class EditModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public EditModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty] public Entity.Usuario Usuario { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(Guid? id)
    {
        if (id == null) return NotFound();

        var usuario = await _context.Usuarios.FirstOrDefaultAsync(m => m.Id == id);
        if (usuario == null) return NotFound();
        Usuario = usuario;
        return Page();
    }

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more information, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        _context.Attach(Usuario).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!UsuarioExists(Usuario.Id)) return NotFound();

            throw;
        }

        return RedirectToPage("./Index");
    }

    private bool UsuarioExists(Guid id)
    {
        return _context.Usuarios.Any(e => e.Id == id);
    }
}