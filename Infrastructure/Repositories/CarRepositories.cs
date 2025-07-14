using Domain.ApiResponses;
using Domain.DTOs.CarDTOs;
using Domain.Entities;
using Domain.Filters;
using Domain.Paginations;
using Infrastructure.Data;
using Infrastructure.Interfaces.ICarServices;

namespace Infrastructure.Repositories;

public class CarRepositories(DataContext context) : ICarRepositories
{
    public async Task<PagedResponse<List<Car>>> GetAllAsync(CarFilters filter)
    {
        var query =  context.Cars.AsQueryable();

        if (!string.IsNullOrEmpty(filter.Model))
        {
            query = query.Where(c => c.Model!.ToLower().Contains(filter.Model.ToLower()));
        }

        if (filter.MaxPricePerDay != null)
        {
            query = query.Where(c => c.PricePerDay > filter.MaxPricePerDay);
        }

        if (filter.MinPricePerDay != null)
        {
            query = query.Where(c => c.PricePerDay < filter.MinPricePerDay);
        }

        var pagination = new Pagination<Car>(query);
        return await pagination.GetPagedResponseAsync(filter.PageNumber, filter.PageSize);
    }

    public async Task<Response<int>> CreateCarAsync(Car car)
    {
        await context.Cars.AddAsync(car);
        await context.SaveChangesAsync();
        return new Response<int>(default!, "All Worked");
    }

    public async Task<Response<int>> UpdateCarAsync(Car car)
    {
        var car1 = context.Update(car);
        await context.SaveChangesAsync();
        return new Response<int>(default!, "All Worked");
    }

    public async Task<Response<int>> DeleteCarAsync(int id)
    {
        var car = await context.Cars.FindAsync(id);
        if (car == null)
        {
            return new Response<int>(default!, "Car not found");
        }
        context.Cars.Remove(car);
        await context.SaveChangesAsync();
        return new Response<int>(default!, "All Worked");
    }
}