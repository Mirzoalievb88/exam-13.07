using Domain.DTOs.StaticksDTOs;
using Domain.Filters;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using WebApi.Interfaces;

namespace Infrastructure.Services;

public class StaticksService(DataContext context) :  IStaticksService
{
    public async Task<decimal> GetTotalRevenueAsync(DateRentalFilter filter)
    {
        return await context.Rentals
            .Where(r => r.StartDate >= filter.StartDate && r.EndDate <= filter.EndDate)
            .SumAsync(r => r.ToTalCost);
    }

    public async Task<List<SimpleCarLoadDto>> GetCarLoadStatisticsAsync(DateRentalFilter filter)
    {
        var carStats = await context.Rentals
                .Where(r => r.StartDate >= filter.StartDate && r.EndDate <= filter.EndDate)
                .GroupBy(r => new { r.Car.Id, r.Car.Model })
                .Select(g => new SimpleCarLoadDto
                {
                    CarId = g.Key.Id,
                    Model = g.Key.Model,
                    RentalCount = g.Count()
                })
                .OrderByDescending(x => x.RentalCount)
                .ToListAsync();
        return carStats;
    }

    public async Task<List<TopCarDto>> GetTop5CarsSimpleAsync()
    {
        var monthAgo = DateTime.UtcNow.AddDays(-30);

        var topCars = await context.Rentals
            .Where(r => r.StartDate >= monthAgo)
            .GroupBy(r => new { r.Car.Model })
            .Select(g => new TopCarDto
            {
                Model = g.Key.Model,
                RentalCount = g.Count()
            })
            .OrderByDescending(x => x.RentalCount)
            .Take(5)
            .ToListAsync();

        return topCars;
    }
}