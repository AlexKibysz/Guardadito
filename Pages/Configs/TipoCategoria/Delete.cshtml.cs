using Guardadito.Data;
using Guardadito.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Guardadito.Pages.Config.TipoCategoria;

public class DeleteModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public DeleteModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty] public CategoryType CategoryType { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(Guid? id)
    {
        if (id == null) return NotFound();

        var categorytype = await _context.CategoryType.FirstOrDefaultAsync(m => m.Id == id);

        if (categorytype is not null)
        {
            CategoryType = categorytype;

            return Page();
        }

        return NotFound();
    }

    public async Task<IActionResult> OnPostAsync(Guid? id)
    {
        if (id == null) return NotFound();

        var categorytype = await _context.CategoryType.FindAsync(id);
        if (categorytype != null)
        {
            CategoryType = categorytype;
            _context.CategoryType.Remove(CategoryType);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}