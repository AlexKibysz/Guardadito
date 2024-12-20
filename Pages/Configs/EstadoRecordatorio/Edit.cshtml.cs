using Guardadito.Data;
using Guardadito.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Guardadito.Pages.Config.EstadoRecordatorio;

public class EditModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public EditModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty] public ReminderStatus ReminderStatus { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(Guid? id)
    {
        if (id == null) return NotFound();

        var reminderstatus = await _context.ReminderStatus.FirstOrDefaultAsync(m => m.Id == id);
        if (reminderstatus == null) return NotFound();
        ReminderStatus = reminderstatus;
        return Page();
    }

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more information, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        _context.Attach(ReminderStatus).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ReminderStatusExists(ReminderStatus.Id)) return NotFound();

            throw;
        }

        return RedirectToPage("./Index");
    }

    private bool ReminderStatusExists(Guid id)
    {
        return _context.ReminderStatus.Any(e => e.Id == id);
    }
}