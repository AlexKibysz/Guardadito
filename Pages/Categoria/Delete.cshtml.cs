using Guardadito.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Guardadito.Pages.Categoria;

public class DeleteModel : PageModel
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<DeleteModel> _logger;

    public DeleteModel(ApplicationDbContext context, ILogger<DeleteModel> logger)
    {
        this._context = context;
        this._logger = logger;
    }

    [BindProperty] public Entity.Categoria Categoria { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(Guid? id)
    {
        if (id == null)
        {
            this._logger.LogWarning("Intento de acceder a Delete sin ID");
            return this.NotFound();
        }

        var categoria = await this._context.Categorias
            .Include(c => c.TipoCategoria)
            .Include(c => c.CategoriaPadre)
            .Include(c => c.SubCategorias)
            .FirstOrDefaultAsync(m => m.Id == id);

        if (categoria == null)
        {
            this._logger.LogWarning("Categoría con ID {CategoriaId} no encontrada", id);
            return this.NotFound();
        }

        // Obtener el conteo de subcategorías directas
        var subcategoriasCount = await this._context.Categorias
            .CountAsync(c => c.CategoriaPadreId == id);

        this._logger.LogInformation(
            "Cargando categoría {CategoriaId} para eliminar. Tiene {SubcategoriasCount} subcategorías",
            id, subcategoriasCount);

        this.ViewData["SubcategoriasCount"] = subcategoriasCount;
        this.Categoria = categoria;
        return this.Page();
    }

    public async Task<IActionResult> OnPostAsync(Guid? id)
    {
        if (id == null)
        {
            this._logger.LogWarning("Intento de eliminar sin ID");
            return this.NotFound();
        }

        try
        {
            var categoria = await this._context.Categorias
                .Include(c => c.TipoCategoria)
                .Include(c => c.CategoriaPadre)
                .Include(c => c.SubCategorias)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (categoria == null)
            {
                this._logger.LogWarning("Categoría con ID {CategoriaId} no encontrada al intentar eliminar", id);
                return this.NotFound();
            }

            this.Categoria = categoria;
            this._logger.LogInformation(
                "Eliminando categoría {CategoriaId} - {CategoriaNombre}",
                categoria.Id,
                categoria.Nombre);

            this._context.Categorias.Remove(this.Categoria);
            await this._context.SaveChangesAsync();

            this._logger.LogInformation("Categoría {CategoriaId} eliminada exitosamente", id);
            return this.RedirectToPage("./Index");
        }
        catch (Exception ex)
        {
            this._logger.LogError(ex, "Error al eliminar la categoría {CategoriaId}", id);
            this.ModelState.AddModelError(string.Empty, "Ha ocurrido un error al eliminar la categoría.");
            return this.Page();
        }
    }
}