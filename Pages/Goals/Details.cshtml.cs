using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Guardadito.Data;
using Guardadito.Entity;

namespace Guardadito.Pages.Goals
{
    public class DetailsModel : PageModel
    {
        private readonly Guardadito.Data.ApplicationDbContext _context;

        public DetailsModel(Guardadito.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Meta Meta { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meta = await _context.Metas.FirstOrDefaultAsync(m => m.Id == id);

            if (meta is not null)
            {
                Meta = meta;

                return Page();
            }

            return NotFound();
        }
    }
}
