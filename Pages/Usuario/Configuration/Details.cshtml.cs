using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Guardadito.Data;
using Guardadito.Entity;

namespace Guardadito.Pages.Usuario.Configuration
{
    public class DetailsModel : PageModel
    {
        private readonly Guardadito.Data.ApplicationDbContext _context;

        public DetailsModel(Guardadito.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public ConfiguracionUsuario ConfiguracionUsuario { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var configuracionusuario = await _context.ConfiguracionesUsuario.FirstOrDefaultAsync(m => m.Id == id);

            if (configuracionusuario is not null)
            {
                ConfiguracionUsuario = configuracionusuario;

                return Page();
            }

            return NotFound();
        }
    }
}
