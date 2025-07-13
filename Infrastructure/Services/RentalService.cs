using System.Net;
using AutoMapper;
using Domain.ApiResponses;
using Domain.DTOs.RentalDTOs;
using Domain.Filters;
using Domain.Paginations;
using Infrastructure.Data;
using Infrastructure.Interfaces.IRentalsServices;
using Infrastructure.Mappers;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class RentalService(DataContext context,
    IRentalRepositories rentalRepositories, IMapper mapper) : IRentalService
{
    public async Task<PagedResponse<List<GetRentalsDto>>> GetRentalsAsync(RentalFilters filters)
    {
        var validFilter = new ValidFilter(filters.PageNumber, filters.PageSize);
        var query = context.Rentals.AsQueryable();

        if (filters.StartDate != null)
        {
             query = query.Where(rental => rental.StartDate >= filters.StartDate);
        }

        if (filters.EndDate != null)
        {
            query = query.Where(rental => rental.EndDate >= filters.EndDate);
        }
        
        var totalRecords = await query.CountAsync();
        var paged = await query
            .Skip((filters.PageNumber - 1) * filters.PageSize)
            .Take(filters.PageSize)
            .ToListAsync();
        
        var rentals = mapper.Map<List<GetRentalsDto>>(paged);
        return new PagedResponse<List<GetRentalsDto>>(rentals, totalRecords, validFilter.PageNumber, validFilter.PageSize);
    }

    public async Task<Response<string>> CreateRentalAsync(CreateRentalDto rentalDto)
    {
        var rental = RentalMapper.ToEntity(rentalDto);
        var result = await rentalRepositories.CreateRentalAsync(rentalDto);
        if (result == null!)
        {
            return new Response<string>("Error", HttpStatusCode.InternalServerError);
        }

        return new Response<string>(default!, "All Worked");
    }

    public async Task<Response<string>> UpdateRentalAsync(int id, UpdateRentalDto rentalDto)
    {
        var rental = await context.Rentals.FindAsync(id);
        if (rental == null)
        {
            return new Response<string>("Error", HttpStatusCode.NotFound);
        }
        
        rental.ToEntity(rentalDto);
        var result = await context.SaveChangesAsync();
        
        return result == 0
            ? new Response<string>("Error", HttpStatusCode.InternalServerError)
            :new Response<string>(default!, "All Worked");
    }

    public async Task<Response<string>> DeleteRentalAsync(int id)
    {
        var rental = await context.Rentals.FindAsync(id);
        if (rental == null)
        {
            return new Response<string>("Error", HttpStatusCode.NotFound);
        }
        
        context.Rentals.Remove(rental);
        var result = await context.SaveChangesAsync();
        
        return result == 0
            ? new Response<string>("Error", HttpStatusCode.InternalServerError)
            : new Response<string>(default!, "All Worked");
    }
}