using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Guardadito.Data;
using Guardadito.Entity;

namespace Guardadito.Pages.Config.Prioridad
{
    public class DetailsModel : PageModel
    {
        private readonly Guardadito.Data.ApplicationDbContext _context;

        public DetailsModel(Guardadito.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Priority Priority { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var priority = await _context.Priority.FirstOrDefaultAsync(m => m.Id == id);

            if (priority is not null)
            {
                Priority = priority;

                return Page();
            }

            return NotFound();
        }
    }
}