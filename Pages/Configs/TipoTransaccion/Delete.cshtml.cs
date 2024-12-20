using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Guardadito.Data;
using Guardadito.Entity;

namespace Guardadito.Pages.Config.TipoTransaccion
{
    public class DeleteModel : PageModel
    {
        private readonly Guardadito.Data.ApplicationDbContext _context;

        public DeleteModel(Guardadito.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TransactionType TransactionType { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transactiontype = await _context.TransactionType.FirstOrDefaultAsync(m => m.Id == id);

            if (transactiontype is not null)
            {
                TransactionType = transactiontype;

                return Page();
            }

            return NotFound();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transactiontype = await _context.TransactionType.FindAsync(id);
            if (transactiontype != null)
            {
                TransactionType = transactiontype;
                _context.TransactionType.Remove(TransactionType);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
