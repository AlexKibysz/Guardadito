using Guardadito.Data;
using Guardadito.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;

namespace Guardadito.Pages.Categoria;

public class CreateModel : PageModel
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<CreateModel> _logger;

    public CreateModel(ApplicationDbContext context, ILogger<CreateModel> logger)
    {
        _context = context;
        _logger = logger;
    }

    [BindProperty] public Entity.Categoria Categoria { get; set; } = default!;

    private void LoadViewData()
    {
        // Lista de iconos
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

        // Categorías padre
        var categoriasRaiz = _context.Categorias
            .Where(c => c.CategoriaPadreId == null)
            .Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = $"{c.Nombre} {c.Icono}"
            })
            .ToList();

        // Tipos de categoría
        var tiposCategoria = _context.CategoryType
            .Select(t => new SelectListItem
            {
                Value = t.Id.ToString(),
                Text = t.Name
            })
            .ToList();

        ViewData["TipoCategoriaId"] = tiposCategoria;
        ViewData["CategoriaPadreId"] = categoriasRaiz;
    }

    public IActionResult OnGet()
    {
        LoadViewData();
        return Page();
    }

    // For more information, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        _logger.LogInformation("OnPostAsync called");

        // Ensure SubCategorias and Transacciones are initialized
        Categoria.SubCategorias = Categoria.SubCategorias ?? new List<Entity.Categoria>();
        Categoria.Transacciones = Categoria.Transacciones ?? new List<Entity.Transaccion>();

        if (!ModelState.IsValid)
        {
            _logger.LogWarning("ModelState is invalid");
            LoadViewData();
            return Page();
        }

        // Si tiene padre, establecer la relación
        if (Categoria.CategoriaPadreId.HasValue)
        {
            var categoriaPadre = await _context.Categorias
                .FindAsync(Categoria.CategoriaPadreId);

            if (categoriaPadre != null)
            {
                categoriaPadre.AddSubcategoria(Categoria);
            }
        }

        _context.Categorias.Add(Categoria);
        await _context.SaveChangesAsync();

        _logger.LogInformation("Categoria created successfully");

        return RedirectToPage("./Index");
    }
}