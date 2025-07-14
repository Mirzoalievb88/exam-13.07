using System.Net;
using AutoMapper;
using Domain.ApiResponses;
using Domain.DTOs.CarDTOs;
using Domain.Entities;
using Domain.Filters;
using Domain.Paginations;
using Infrastructure.Data;
using Infrastructure.Interfaces.ICarServices;
using Infrastructure.Mappers;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.Cars;

public class CarService(
    DataContext context, 
    ICarRepositories carRepositories, 
    IMapper mapper) : ICarService
{
    public async Task<PagedResponse<List<GetCarDto>>> GetAllCarsAsync(CarFilters filters)
    {
        var validFilter = new ValidFilter(filters.PageNumber, filters.PageSize);
        var query = context.Cars.AsQueryable();

        if (!string.IsNullOrEmpty(filters.Model))
        {
            query = query.Where(c => c.Model.ToLower().Contains(filters.Model.ToLower()));
        }

        if (filters.MinPricePerDay != null)
        {
            query = query.Where(c => c.PricePerDay >= filters.MinPricePerDay);
        }

        if (filters.MaxPricePerDay != null)
        {
            query = query.Where(c => c.PricePerDay <= filters.MaxPricePerDay);
        }
        
        var totalRecords = await query.CountAsync();
        
        var paged = await query
            .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
            .Take(validFilter.PageSize)
            .ToListAsync();
        var mapped = mapper.Map<List<GetCarDto>>(paged);
        
        return new PagedResponse<List<GetCarDto>>(mapped, totalRecords, validFilter.PageNumber,
            validFilter.PageSize);
    }

    public async Task<Response<string>> CreateCarAsync(CreateCarDto carDto)
    {
        var car = CarMapper.ToEntity(carDto);
        var result = await carRepositories.CreateCarAsync(car);

        if (result == null!)
        {
            return new Response<string>("Error", HttpStatusCode.NotFound);   
        }

        return new Response<string>(default!, "All Worked");
    }

    public async Task<Response<string>> UpdateCarAsync(int id, UpdateCarDto carDto)
    {
        var car = await context.Cars.FindAsync(id);
        if (car == null)
        {
            return new Response<string>("Error", HttpStatusCode.NotFound);
        }
        
        car.ToEntity(carDto);
        var result = await carRepositories.UpdateCarAsync(car);
        
        return result == null!
            ? new Response<string>("Error", HttpStatusCode.NotFound)
            : new Response<string>(default,$"Updated Car");
    }

    public async Task<Response<string>> DeleteCarAsync(int id)
    {
        var car = await context.Cars.FindAsync(id);
        if (car == null)
        {
            return new Response<string>("Error", HttpStatusCode.NotFound);
        }
        
        context.Cars.Remove(car);
        var result = await context.SaveChangesAsync();
        
        return result == 0
            ? new Response<string>("Something went wrong",  HttpStatusCode.NotFound)
            : new Response<string>(null, "Course updated successfully");
    }
}