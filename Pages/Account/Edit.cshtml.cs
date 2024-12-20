using Guardadito.Data;
using Guardadito.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Guardadito.Pages.Account;

public class EditModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public EditModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty] public Cuenta Cuenta { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(Guid? id)
    {
        if (id == null) return NotFound();

        var cuenta = await _context.Cuentas.FirstOrDefaultAsync(m => m.Id == id);
        if (cuenta == null) return NotFound();
        Cuenta = cuenta;
        ViewData["MonedaPrincipalId"] = new SelectList(_context.Currencies, "Id", "Code");
        ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Email");
        return Page();
    }

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more information, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        _context.Attach(Cuenta).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CuentaExists(Cuenta.Id)) return NotFound();

            throw;
        }

        return RedirectToPage("./Index");
    }

    private bool CuentaExists(Guid id)
    {
        return _context.Cuentas.Any(e => e.Id == id);
    }
}