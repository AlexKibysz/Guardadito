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

namespace Guardadito.Pages.Categoria
{
    public class EditModel : PageModel
    {
        private readonly Guardadito.Data.ApplicationDbContext _context;

        public EditModel(Guardadito.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Entity.Categoria Categoria { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoria =  await _context.Categorias.FirstOrDefaultAsync(m => m.Id == id);
            if (categoria == null)
            {
                return NotFound();
            }
            Categoria = categoria;
           ViewData["CategoriaPadreId"] = new SelectList(_context.Categorias, "Id", "Color");
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

            _context.Attach(Categoria).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoriaExists(Categoria.Id))
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

        private bool CategoriaExists(Guid id)
        {
            return _context.Categorias.Any(e => e.Id == id);
        }
    }
}
