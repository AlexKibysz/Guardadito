using Guardadito.Data;
using Guardadito.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Guardadito.Pages.Config.EstadoRecordatorio;

public class DetailsModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public DetailsModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public ReminderStatus ReminderStatus { get; set; } = default!;

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
}