using Guardadito.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        var usuario = await _context.Usuarios.Include(u => u.Rol).FirstOrDefaultAsync(m => m.Id == id);
        if (usuario == null) return NotFound();
        Usuario = usuario;

        ViewData["RolId"] = new SelectList(_context.UserRole, "Id", "Name", Usuario.RolId);
        return Page();
    }

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more information, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync(Guid? id)
    {
        if (!ModelState.IsValid) return Page();

        var usuarioToUpdate = await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == Usuario.Id);

        if (usuarioToUpdate == null) return NotFound();

        if (await TryUpdateModelAsync(
            usuarioToUpdate,
            "Usuario",
            u => u.Nombre, u => u.Email, u => u.PasswordHash, u => u.RolId))
        {
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

        ViewData["RolId"] = new SelectList(_context.UserRole, "Id", "Name", Usuario.RolId);
        return Page();
    }

    private bool UsuarioExists(Guid id)
    {
        return _context.Usuarios.Any(e => e.Id == id);
    }
}