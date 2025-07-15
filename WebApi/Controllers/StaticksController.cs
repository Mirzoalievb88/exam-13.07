using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;
using Domain.Filters;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StatisticsController(DataContext context) : ControllerBase
{
    [HttpGet("revenue")]
    public async Task<ActionResult<decimal>> GetRevenue([FromQuery] DateRentalFilter filter)
    {
        var revenue = await context.Rentals
            .Where(r => r.StartDate >= filter.StartDate && r.EndDate <= filter.EndDate)
            .SumAsync(r => r.ToTalCost);

        return Ok(revenue);
    }

    [HttpGet("car-usage")]
    public async Task<ActionResult> GetCarUsage([FromQuery] DateRentalFilter filter)
    {
        var stats = await context.Rentals
            .Where(r => r.StartDate >= filter.StartDate && r.EndDate <= filter.EndDate)
            .GroupBy(r => new { r.Car.Id, r.Car.Model })
            .Select(g => new
            {
                CarId = g.Key.Id,
                Model = g.Key.Model,
                RentalCount = g.Count()
            })
            .OrderByDescending(x => x.RentalCount)
            .ToListAsync();

        return Ok(stats);
    }

    [HttpGet("top5-models")]
    public async Task<ActionResult> GetTop5PopularModels()
    {
        var monthAgo = DateTime.UtcNow.AddDays(-30);

        var topCars = await context.Rentals
            .Where(r => r.StartDate >= monthAgo)
            .GroupBy(r => new { r.Car.Model})
            .Select(g => new
            {
                g.Key.Model,
                RentalCount = g.Count()
            })
            .OrderByDescending(x => x.RentalCount)
            .Take(5)
            .ToListAsync();

        return Ok(topCars);
    }
}