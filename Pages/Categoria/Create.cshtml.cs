using Guardadito.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Guardadito.Pages.Categoria;

public class CreateModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public CreateModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty] public Entity.Categoria Categoria { get; set; } = default!;

    public IActionResult OnGet()
    {
        ViewData["CategoriaPadreId"] = new SelectList(_context.Categorias, "Id", "Color");
        return Page();
    }

    // For more information, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        _context.Categorias.Add(Categoria);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}