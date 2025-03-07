using Guardadito.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Guardadito.Pages.CategoriaPresupuesto;

public class EditModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public EditModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty] public Entity.CategoriaPresupuesto CategoriaPresupuesto { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(Guid? id)
    {
        if (id == null) return NotFound();

        var categoriapresupuesto = await _context.CategoriasPresupuesto.FirstOrDefaultAsync(m => m.Id == id);
        if (categoriapresupuesto == null) return NotFound();
        CategoriaPresupuesto = categoriapresupuesto;
        ViewData["PresupuestoId"] = new SelectList(_context.Presupuestos, "Id", "Nombre");
        return Page();
    }

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more information, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        _context.Attach(CategoriaPresupuesto).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CategoriaPresupuestoExists(CategoriaPresupuesto.Id)) return NotFound();

            throw;
        }

        return RedirectToPage("./Index");
    }

    private bool CategoriaPresupuestoExists(Guid id)
    {
        return _context.CategoriasPresupuesto.Any(e => e.Id == id);
    }
}