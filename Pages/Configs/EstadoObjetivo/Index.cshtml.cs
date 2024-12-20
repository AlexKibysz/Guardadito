using Guardadito.Data;
using Guardadito.Entity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Guardadito.Pages.Config.EstadoObjetivo;

public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public IndexModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public IList<GoalStatus> GoalStatus { get; set; } = default!;

    public async Task OnGetAsync()
    {
        GoalStatus = await _context.GoalStatus.ToListAsync();
    }
}