using Guardadito.Data;
using Guardadito.Entity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Guardadito.Pages.Config.RolUsuario;

public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public IndexModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public IList<UserRole> UserRole { get; set; } = default!;

    public async Task OnGetAsync()
    {
        UserRole = await _context.UserRole.ToListAsync();
    }
}