using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Guardadito.Data;
using Guardadito.Entity;

namespace Guardadito.Pages.Reminder
{
    public class IndexModel : PageModel
    {
        private readonly Guardadito.Data.ApplicationDbContext _context;

        public IndexModel(Guardadito.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Recordatorio> Recordatorio { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Recordatorio = await _context.Recordatorios
                .Include(r => r.Usuario).ToListAsync();
        }
    }
}
