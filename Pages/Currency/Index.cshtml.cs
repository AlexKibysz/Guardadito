using Guardadito.Data;
using Guardadito.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Guardadito.Pages.Currency;

public class Index : PageModel
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<Index> _logger;

    public Index(ApplicationDbContext context, ILogger<Index> logger)
    {
        _context = context;
        _logger = logger;
    }

    public PaginatedList<Entity.Currency> Currencies { get; set; }

    [BindProperty(SupportsGet = true)]
    public string SearchTerm { get; set; }

    [BindProperty(SupportsGet = true)]
    public string SortOrder { get; set; }

    [BindProperty(SupportsGet = true)]
    public bool? IsActive { get; set; }

    [BindProperty(SupportsGet = true)]
    [Range(1, 100)]
    public int PageSize { get; set; } = 10;

    [BindProperty(SupportsGet = true)]
    [Range(1, int.MaxValue)]
    public int CurrentPage { get; set; } = 1;

    public string NameSort { get; set; }
    public string CodeSort { get; set; }
    public string RateSort { get; set; }

    public async Task<IActionResult> OnGetAsync()
    {
        try
        {
            // Validar parámetros de paginación
            if (CurrentPage < 1) CurrentPage = 1;
            if (PageSize < 1) PageSize = 10;
            if (PageSize > 100) PageSize = 100;

            IQueryable<Entity.Currency> currencyQuery = _context.Currencies.AsNoTracking();

            // Configurar ordenamiento
            NameSort = SortOrder == "name" ? "name_desc" : "name";
            CodeSort = SortOrder == "code" ? "code_desc" : "code";
            RateSort = SortOrder == "rate" ? "rate_desc" : "rate";

            // Aplicar filtros
            if (!string.IsNullOrEmpty(SearchTerm))
            {
                var searchTermLower = SearchTerm.ToLower();
                currencyQuery = currencyQuery.Where(c =>
                    c.Name.ToLower().Contains(searchTermLower) ||
                    c.Code.ToLower().Contains(searchTermLower) ||
                    c.Symbol.ToLower().Contains(searchTermLower));
            }

            if (IsActive.HasValue)
            {
                currencyQuery = currencyQuery.Where(c => c.IsActive == IsActive.Value);
            }

            // Aplicar ordenamiento
            currencyQuery = SortOrder switch
            {
                "name" => currencyQuery.OrderBy(c => c.Name),
                "name_desc" => currencyQuery.OrderByDescending(c => c.Name),
                "code" => currencyQuery.OrderBy(c => c.Code),
                "code_desc" => currencyQuery.OrderByDescending(c => c.Code),
                "rate" => currencyQuery.OrderBy(c => c.ExchangeRate),
                "rate_desc" => currencyQuery.OrderByDescending(c => c.ExchangeRate),
                _ => currencyQuery.OrderBy(c => c.Name)
            };

            // Paginación
            var count = await currencyQuery.CountAsync();
            var items = await currencyQuery
                .Skip((CurrentPage - 1) * PageSize)
                .Take(PageSize)
                .ToListAsync();

            Currencies = new PaginatedList<Entity.Currency>(
                items, count, CurrentPage, PageSize);

            return Page();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al cargar la página de monedas");
            TempData["ErrorMessage"] = "Ha ocurrido un error al cargar las monedas. Por favor, inténtelo de nuevo.";
            return RedirectToPage("/Error");
        }
    }
}

// Clase auxiliar para paginación simplificada
public class PaginatedList<T> : List<T>
{
    public int PageIndex { get; }
    public int TotalPages { get; }
    public int TotalItems { get; }

    public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
    {
        PageIndex = pageIndex;
        TotalItems = count;
        TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        AddRange(items);
    }

    public bool HasPreviousPage => PageIndex > 1;
    public bool HasNextPage => PageIndex < TotalPages;
}