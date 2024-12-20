using Guardadito.Data;
using Guardadito.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Guardadito.Pages.Config.TipoRecordatorio;

public class DeleteModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public DeleteModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty] public ReminderType ReminderType { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(Guid? id)
    {
        if (id == null) return NotFound();

        var remindertype = await _context.ReminderType.FirstOrDefaultAsync(m => m.Id == id);

        if (remindertype is not null)
        {
            ReminderType = remindertype;

            return Page();
        }

        return NotFound();
    }

    public async Task<IActionResult> OnPostAsync(Guid? id)
    {
        if (id == null) return NotFound();

        var remindertype = await _context.ReminderType.FindAsync(id);
        if (remindertype != null)
        {
            ReminderType = remindertype;
            _context.ReminderType.Remove(ReminderType);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}