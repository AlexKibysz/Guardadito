using Guardadito.Data;
using Guardadito.Entity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Guardadito.Pages.Config.TipoRecordatorio;

public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public IndexModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public IList<ReminderType> ReminderType { get; set; } = default!;

    public async Task OnGetAsync()
    {
        ReminderType = await _context.ReminderType.ToListAsync();
    }
}