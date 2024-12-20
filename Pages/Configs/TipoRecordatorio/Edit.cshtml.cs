using Guardadito.Data;
using Guardadito.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Guardadito.Pages.Config.TipoRecordatorio;

public class EditModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public EditModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty] public ReminderType ReminderType { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(Guid? id)
    {
        if (id == null) return NotFound();

        var remindertype = await _context.ReminderType.FirstOrDefaultAsync(m => m.Id == id);
        if (remindertype == null) return NotFound();
        ReminderType = remindertype;
        return Page();
    }

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more information, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        _context.Attach(ReminderType).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ReminderTypeExists(ReminderType.Id)) return NotFound();

            throw;
        }

        return RedirectToPage("./Index");
    }

    private bool ReminderTypeExists(Guid id)
    {
        return _context.ReminderType.Any(e => e.Id == id);
    }
}