using Guardadito.Data;
using Guardadito.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Guardadito.Pages.Usuario;

public class CreateModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public CreateModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty] public Entity.Usuario Usuario { get; set; } = default!;

    public IActionResult OnGet()
    {
        Usuario = new Entity.Usuario
        {
            Cuentas = new List<Cuenta>(),
            Transacciones = new List<Transaccion>(),
            Metas = new List<Meta>(),
            Presupuestos = new List<Presupuesto>(),
        };

        ViewData["RolId"] = new SelectList(_context.UserRole, "Id", "Name");
        return Page();
    }

    //TODO: Agregar Validacion de Presupuesto si no supera al presupuesto restante del padre
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            ViewData["RolId"] = new SelectList(_context.UserRole, "Id", "Name", Usuario.RolId);
            return Page();
        }

        var userRole = await _context.UserRole.FindAsync(Usuario.RolId);
        if (userRole == null)
        {
            ModelState.AddModelError("CrearUsuario.RolId", "El rol seleccionado no es válido");
            ViewData["RolId"] = new SelectList(_context.UserRole, "Id", "Name", Usuario.RolId);
            return Page();
        }

        Usuario.Rol = userRole;

        _context.Usuarios.Add(Usuario);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}