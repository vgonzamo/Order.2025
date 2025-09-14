using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Orders.backend.Data;
using Orders.Shared.Entites;

namespace Orders.backend.Controllers;

[ApiController]
[Route("api/ [Controller]")]

public class CountriesController: ControllerBase
{
    private readonly DataContext _Context;

    public CountriesController(DataContext Context)
    {
        _Context = Context;
    }

    [HttpGet]

    public async Task<IActionResult> GetAsync()
    {
      
        return Ok(await _Context.Countries.ToListAsync());
    }

    [HttpPost]

    public async  Task<IActionResult> PostAsync(Country country)
    {
        _Context.Countries.Add(country);
        await _Context.SaveChangesAsync();
        return Ok(country);
    }

}
