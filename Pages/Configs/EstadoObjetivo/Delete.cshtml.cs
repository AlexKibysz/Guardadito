using Guardadito.Data;
using Guardadito.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Guardadito.Pages.Config.EstadoObjetivo;

public class DeleteModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public DeleteModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty] public GoalStatus GoalStatus { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(Guid? id)
    {
        if (id == null) return NotFound();

        var goalstatus = await _context.GoalStatus.FirstOrDefaultAsync(m => m.Id == id);

        if (goalstatus is not null)
        {
            GoalStatus = goalstatus;

            return Page();
        }

        return NotFound();
    }

    public async Task<IActionResult> OnPostAsync(Guid? id)
    {
        if (id == null) return NotFound();

        var goalstatus = await _context.GoalStatus.FindAsync(id);
        if (goalstatus != null)
        {
            GoalStatus = goalstatus;
            _context.GoalStatus.Remove(GoalStatus);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}