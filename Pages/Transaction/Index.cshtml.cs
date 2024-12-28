using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Guardadito.Data;
using Guardadito.Entity;

namespace Guardadito.Pages.Transaction
{
    public class IndexModel : PageModel
    {
        private readonly Guardadito.Data.ApplicationDbContext _context;

        public IndexModel(Guardadito.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Transaccion> Transaccion { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Transaccion = await _context.Transacciones
                .Include(t => t.Categoria)
                .Include(t => t.Cuenta)
                .Include(t => t.MonedaDestino)
                .Include(t => t.MonedaOriginal)
                .Include(t => t.Usuario).ToListAsync();
        }
    }
}
