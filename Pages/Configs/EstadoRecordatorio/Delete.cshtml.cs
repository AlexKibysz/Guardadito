using Guardadito.Data;
using Guardadito.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Guardadito.Pages.Config.EstadoRecordatorio;

public class DeleteModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public DeleteModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty] public ReminderStatus ReminderStatus { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(Guid? id)
    {
        if (id == null) return NotFound();

        var reminderstatus = await _context.ReminderStatus.FirstOrDefaultAsync(m => m.Id == id);

        if (reminderstatus is not null)
        {
            ReminderStatus = reminderstatus;

            return Page();
        }

        return NotFound();
    }

    public async Task<IActionResult> OnPostAsync(Guid? id)
    {
        if (id == null) return NotFound();

        var reminderstatus = await _context.ReminderStatus.FindAsync(id);
        if (reminderstatus != null)
        {
            ReminderStatus = reminderstatus;
            _context.ReminderStatus.Remove(ReminderStatus);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}