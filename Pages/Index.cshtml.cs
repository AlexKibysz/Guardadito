using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Guardadito.Pages;

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
            new() { Nombre = "Juan Pérez", Edad = 32, Ciudad = "Madrid" },
            new() { Nombre = "María Gómez", Edad = 29, Ciudad = "Barcelona" },
            new() { Nombre = "Carlos López", Edad = 41, Ciudad = "Valencia" },
            new() { Nombre = "Ana Rodríguez", Edad = 35, Ciudad = "Sevilla" },
            new() { Nombre = "Luis Martínez", Edad = 28, Ciudad = "Bilbao" },
            new() { Nombre = "Elena Fernández", Edad = 45, Ciudad = "Málaga" },
            new() { Nombre = "David Sánchez", Edad = 39, Ciudad = "Zaragoza" },
            new() { Nombre = "Sofía Torres", Edad = 33, Ciudad = "Murcia" },
            new() { Nombre = "Miguel Ruiz", Edad = 50, Ciudad = "Palma" },
            new() { Nombre = "Laura García", Edad = 27, Ciudad = "Las Palmas" },
            new() { Nombre = "Javier Moreno", Edad = 44, Ciudad = "Vitoria" },
            new() { Nombre = "Cristina Álvarez", Edad = 36, Ciudad = "Gijón" },
            new() { Nombre = "Daniel Castro", Edad = 31, Ciudad = "A Coruña" },
            new() { Nombre = "Isabel Jiménez", Edad = 42, Ciudad = "Alicante" },
            new() { Nombre = "Alejandro Navarro", Edad = 37, Ciudad = "Córdoba" },
            new() { Nombre = "Raquel Díaz", Edad = 29, Ciudad = "Valladolid" },
            new() { Nombre = "Alberto Muñoz", Edad = 46, Ciudad = "Vigo" },
            new() { Nombre = "Carmen Romero", Edad = 34, Ciudad = "Hospitalet" },
            new() { Nombre = "Ricardo Herrera", Edad = 40, Ciudad = "Granada" },
            new() { Nombre = "Beatriz Núñez", Edad = 38, Ciudad = "Oviedo" },
            new() { Nombre = "Fernando Castro", Edad = 52, Ciudad = "Santa Cruz" },
            new() { Nombre = "Marta Iglesias", Edad = 30, Ciudad = "Badalona" },
            new() { Nombre = "Roberto Molina", Edad = 43, Ciudad = "Cartagena" },
            new() { Nombre = "Diana Suárez", Edad = 33, Ciudad = "Móstoles" },
            new() { Nombre = "Pablo Ortiz", Edad = 36, Ciudad = "Jerez" },
            new() { Nombre = "Verónica Morales", Edad = 31, Ciudad = "Sabadell" },
            new() { Nombre = "Sergio Ramos", Edad = 45, Ciudad = "Alcalá" },
            new() { Nombre = "Patricia López", Edad = 39, Ciudad = "Fuenlabrada" },
            new() { Nombre = "Adrián García", Edad = 27, Ciudad = "Leganés" },
            new() { Nombre = "Silvia Martín", Edad = 34, Ciudad = "Tarragona" }
        };

        // Número de elementos por página
        var elementosPorPagina = 30;

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