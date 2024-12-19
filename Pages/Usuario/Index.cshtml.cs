using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Guardadito.Pages.Usuario
{
    public class IndexModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;

        public IndexModel(Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Entity.Usuario> Usuario { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Usuario = await _context.Usuarios.ToListAsync();
        }
    }
}
