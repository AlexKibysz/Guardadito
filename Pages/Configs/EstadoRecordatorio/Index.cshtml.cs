using Guardadito.Data;
using Guardadito.Entity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Guardadito.Pages.Config.EstadoRecordatorio;

public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public IndexModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public IList<ReminderStatus> ReminderStatus { get; set; } = default!;

    public async Task OnGetAsync()
    {
        ReminderStatus = await _context.ReminderStatus.ToListAsync();
    }
}