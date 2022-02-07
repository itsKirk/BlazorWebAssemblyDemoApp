using BlazorWebAssemblyDemo.Server.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorWebAssemblyDemo.Server.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CountriesController : ControllerBase
{
    private readonly IWebHostEnvironment _environment;
    private readonly ApplicationContext _context;

    public CountriesController(IWebHostEnvironment environment, ApplicationContext context)
    {
        _environment = environment;
        _context = context;
    }
    [HttpGet]
    public async Task<IActionResult> GetCountries()
    {
        try
        {
            return Ok(await _context.Countries
                .OrderBy(x => x.Name)
                .Include(x => x.Media)
                .AsSplitQuery()
                .ToListAsync()
                );
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
            //"Error retrieving data from the database");
        }
    }
    [HttpPost]
    public async Task<IActionResult> Post(List<Country> countries)
    {
        try
        {
            foreach (var country in countries)
            {
                var media = new Media();
                media = country.Media;
                media.Id = 0;
                _context.Media.Add(media);
                await _context.SaveChangesAsync();
                country.Media = media;
                country.Id = 0;
                _context.Countries.Add(country);
                await _context.SaveChangesAsync();
            }
            return StatusCode(201);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}
