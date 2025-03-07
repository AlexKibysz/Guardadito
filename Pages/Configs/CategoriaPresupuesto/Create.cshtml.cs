using Guardadito.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Guardadito.Pages.CategoriaPresupuesto;

public class CreateModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public CreateModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty] public Entity.CategoriaPresupuesto CategoriaPresupuesto { get; set; } = default!;

    public IActionResult OnGet()
    {
        ViewData["PresupuestoId"] = new SelectList(_context.Presupuestos, "Id", "Nombre");

        return Page();
    }


    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            ViewData["PresupuestoId"] = new SelectList(_context.Presupuestos, "Id", "Nombre");
            return Page();
        }

        // Ignorar la navegación para evitar problemas de validación
        CategoriaPresupuesto.Presupuesto = null;
        _context.CategoriasPresupuesto.Add(CategoriaPresupuesto);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}