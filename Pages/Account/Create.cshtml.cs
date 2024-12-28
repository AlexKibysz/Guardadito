using Guardadito.Data;
using Guardadito.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Guardadito.Pages.Account;

public class CreateModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public CreateModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty] public Cuenta Cuenta { get; set; } = default!;

    public IActionResult OnGet()
    {
        ViewData["MonedaPrincipalId"] = new SelectList(_context.Currencies, "Id", "Code");
        ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Email");
        ViewData["TipoCuenta"] = new SelectList(_context.AccountType, "Id", "Name");
        return Page();
    }

    // For more information, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        _context.Cuentas.Add(Cuenta);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }


}