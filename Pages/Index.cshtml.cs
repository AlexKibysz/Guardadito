using Guardadito.Entity.Prueba;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace Guardadito.Pages
{
  public class Index : PageModel
  {
    private readonly ILogger<Index> _logger;

    public Index(ILogger<Index> logger)
    {
      _logger = logger;
    }

    // Lista de ejemplo de personas (esto se podría obtener de una base de datos)
    public List<Persona> Personas { get; set; }
    public List<Persona> Paginado { get; set; }

    public int PaginaActual { get; set; } = 1;
    public int TotalPaginas { get; set; }

    public void OnGet(int pagina = 1)
    {
      // Generate a more diverse and extensive list of personas
      Personas = new List<Persona>
    {
        new Persona { Nombre = "Juan Pérez", Edad = 32, Ciudad = "Madrid" },
        new Persona { Nombre = "María Gómez", Edad = 29, Ciudad = "Barcelona" },
        new Persona { Nombre = "Carlos López", Edad = 41, Ciudad = "Valencia" },
        new Persona { Nombre = "Ana Rodríguez", Edad = 35, Ciudad = "Sevilla" },
        new Persona { Nombre = "Luis Martínez", Edad = 28, Ciudad = "Bilbao" },
        new Persona { Nombre = "Elena Fernández", Edad = 45, Ciudad = "Málaga" },
        new Persona { Nombre = "David Sánchez", Edad = 39, Ciudad = "Zaragoza" },
        new Persona { Nombre = "Sofía Torres", Edad = 33, Ciudad = "Murcia" },
        new Persona { Nombre = "Miguel Ruiz", Edad = 50, Ciudad = "Palma" },
        new Persona { Nombre = "Laura García", Edad = 27, Ciudad = "Las Palmas" },
        new Persona { Nombre = "Javier Moreno", Edad = 44, Ciudad = "Vitoria" },
        new Persona { Nombre = "Cristina Álvarez", Edad = 36, Ciudad = "Gijón" },
        new Persona { Nombre = "Daniel Castro", Edad = 31, Ciudad = "A Coruña" },
        new Persona { Nombre = "Isabel Jiménez", Edad = 42, Ciudad = "Alicante" },
        new Persona { Nombre = "Alejandro Navarro", Edad = 37, Ciudad = "Córdoba" },
        new Persona { Nombre = "Raquel Díaz", Edad = 29, Ciudad = "Valladolid" },
        new Persona { Nombre = "Alberto Muñoz", Edad = 46, Ciudad = "Vigo" },
        new Persona { Nombre = "Carmen Romero", Edad = 34, Ciudad = "Hospitalet" },
        new Persona { Nombre = "Ricardo Herrera", Edad = 40, Ciudad = "Granada" },
        new Persona { Nombre = "Beatriz Núñez", Edad = 38, Ciudad = "Oviedo" },
        new Persona { Nombre = "Fernando Castro", Edad = 52, Ciudad = "Santa Cruz" },
        new Persona { Nombre = "Marta Iglesias", Edad = 30, Ciudad = "Badalona" },
        new Persona { Nombre = "Roberto Molina", Edad = 43, Ciudad = "Cartagena" },
        new Persona { Nombre = "Diana Suárez", Edad = 33, Ciudad = "Móstoles" },
        new Persona { Nombre = "Pablo Ortiz", Edad = 36, Ciudad = "Jerez" },
        new Persona { Nombre = "Verónica Morales", Edad = 31, Ciudad = "Sabadell" },
        new Persona { Nombre = "Sergio Ramos", Edad = 45, Ciudad = "Alcalá" },
        new Persona { Nombre = "Patricia López", Edad = 39, Ciudad = "Fuenlabrada" },
        new Persona { Nombre = "Adrián García", Edad = 27, Ciudad = "Leganés" },
        new Persona { Nombre = "Silvia Martín", Edad = 34, Ciudad = "Tarragona" }
    };

      // Número de elementos por página
      int elementosPorPagina = 30;

      // Total de páginas
      TotalPaginas = (int)Math.Ceiling((double)Personas.Count / elementosPorPagina);

      // Validar la página solicitada
      PaginaActual = pagina > TotalPaginas ? TotalPaginas : pagina;

      // Obtener los elementos de la página actual
      Paginado = Personas.Skip((PaginaActual - 1) * elementosPorPagina).Take(elementosPorPagina).ToList();
    }
    public class Persona
    {
      public string Nombre { get; set; }
      public int Edad { get; set; }
      public string Ciudad { get; set; }
    }
  }
}
