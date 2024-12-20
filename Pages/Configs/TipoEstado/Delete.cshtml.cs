using Guardadito.Data;
using Guardadito.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Guardadito.Pages.Config.TipoEstado;

public class DeleteModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public DeleteModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty] public StatType StatType { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(Guid? id)
    {
        if (id == null) return NotFound();

        var stattype = await _context.StatType.FirstOrDefaultAsync(m => m.Id == id);

        if (stattype is not null)
        {
            StatType = stattype;

            return Page();
        }

        return NotFound();
    }

    public async Task<IActionResult> OnPostAsync(Guid? id)
    {
        if (id == null) return NotFound();

        var stattype = await _context.StatType.FindAsync(id);
        if (stattype != null)
        {
            StatType = stattype;
            _context.StatType.Remove(StatType);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}