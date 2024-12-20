using Guardadito.Data;
using Guardadito.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Guardadito.Pages.Config.Prioridad;

public class DeleteModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public DeleteModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty] public Priority Priority { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(Guid? id)
    {
        if (id == null) return NotFound();

        var priority = await _context.Priority.FirstOrDefaultAsync(m => m.Id == id);

        if (priority is not null)
        {
            Priority = priority;

            return Page();
        }

        return NotFound();
    }

    public async Task<IActionResult> OnPostAsync(Guid? id)
    {
        if (id == null) return NotFound();

        var priority = await _context.Priority.FindAsync(id);
        if (priority != null)
        {
            Priority = priority;
            _context.Priority.Remove(Priority);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}