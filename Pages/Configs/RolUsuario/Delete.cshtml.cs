using Guardadito.Data;
using Guardadito.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Guardadito.Pages.Config.RolUsuario;

public class DeleteModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public DeleteModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty] public UserRole UserRole { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(Guid? id)
    {
        if (id == null) return NotFound();

        var userrole = await _context.UserRole.FirstOrDefaultAsync(m => m.Id == id);

        if (userrole is not null)
        {
            UserRole = userrole;

            return Page();
        }

        return NotFound();
    }

    public async Task<IActionResult> OnPostAsync(Guid? id)
    {
        if (id == null) return NotFound();

        var userrole = await _context.UserRole.FindAsync(id);
        if (userrole != null)
        {
            UserRole = userrole;
            _context.UserRole.Remove(UserRole);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}