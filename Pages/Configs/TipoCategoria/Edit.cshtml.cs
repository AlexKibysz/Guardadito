using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Guardadito.Data;
using Guardadito.Entity;

namespace Guardadito.Pages.Config.TipoCategoria
{
    public class EditModel : PageModel
    {
        private readonly Guardadito.Data.ApplicationDbContext _context;

        public EditModel(Guardadito.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CategoryType CategoryType { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categorytype =  await _context.CategoryType.FirstOrDefaultAsync(m => m.Id == id);
            if (categorytype == null)
            {
                return NotFound();
            }
            CategoryType = categorytype;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(CategoryType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryTypeExists(CategoryType.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CategoryTypeExists(Guid id)
        {
            return _context.CategoryType.Any(e => e.Id == id);
        }
    }
}