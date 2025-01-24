using Guardadito.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Guardadito.Pages.Categoria;

public class EditModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public EditModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty] public Entity.Categoria Categoria { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(Guid? id)
    {
        if (id == null) return NotFound();

        var categoria = await _context.Categorias
            .Include(c => c.TipoCategoria)
            .FirstOrDefaultAsync(m => m.Id == id);

        if (categoria == null) return NotFound();

        Categoria = categoria;

        ViewData["CategoriaPadreId"] = new SelectList(await _context.Categorias
            .Where(c => c.Id != id)
            .OrderBy(c => c.Nombre)
            .ToListAsync(), "Id", "Nombre");

        ViewData["TipoCategoriaId"] = new SelectList(await _context.CategoryType
            .OrderBy(t => t.Name)
            .ToListAsync(), "Id", "Name");

        ViewData["Iconos"] = new List<SelectListItem>
        {
            new SelectListItem("💰 Ingreso", "fas fa-solid fa-money-bill-trend-up"),
            new SelectListItem("💳 Gastos", "fas fa-solid fa-credit-card"),
            new SelectListItem("🏠 Hogar", "fas fa-solid fa-house"),
            new SelectListItem("🚗 Transporte", "fa-solid fa-car"),
            new SelectListItem("🏥 Salud", "fa-solid fa-hospital"),
            new SelectListItem("🛒 Compras", "fa-solid fa-cart-shopping"),
            new SelectListItem("🍽️ Comida", "fa-solid fa-utensils"),
            new SelectListItem("📱 Servicios", "fa-solid fa-mobile-screen"),
            new SelectListItem("🎮 Entretenimiento", "fa-solid fa-gamepad"),
            new SelectListItem("💼 Trabajo", "fa-solid fa-briefcase"),
            new SelectListItem("📚 Educación", "fa-solid fa-graduation-cap"),
            new SelectListItem("💰 Ahorros", "fa-solid fa-piggy-bank"),
            new SelectListItem("💳 Inversiones", "fa-solid fa-chart-line"),
            new SelectListItem("🏦 Banco", "fa-solid fa-building-columns")
        };

        return Page();
    }


    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        _context.Attach(Categoria).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CategoriaExists(Categoria.Id)) return NotFound();

            throw;
        }

        return RedirectToPage("./Index");
    }

    private bool CategoriaExists(Guid id)
    {
        return _context.Categorias.Any(e => e.Id == id);
    }
}