using System.Net;
using Domain.ApiResponses;
using Domain.DTOs.RentalDTOs;
using Domain.Entities;
using Domain.Filters;
using Domain.Paginations;
using Infrastructure.Data;
using Infrastructure.Interfaces.IRentalsServices;

namespace Infrastructure.Repositories;

public class RentalRepositories(DataContext context) : IRentalRepositories
{
    public async Task<PagedResponse<List<Rentals>>> GetAllRentalsAsync(RentalFilters filters)
    {
        var query = context.Rentals.AsQueryable();
        if (filters.StartDate != null)
        {
            query = query.Where(r => r.StartDate == filters.StartDate);
        }

        if (filters.EndDate != null)
        {
            query = query.Where(r => r.EndDate == filters.EndDate);
        }

        var pagination = new Pagination<Rentals>(query);
        return await pagination.GetPagedResponseAsync(filters.PageNumber,  filters.PageSize);
    }

    public async Task<Response<int>> CreateRentalAsync(Rentals rentals)
    {
        await context.Rentals.AddAsync(rentals);
        await context.SaveChangesAsync();
        return new Response<int>(default!, "Branch Created");
    }

    public async Task<Response<int>> UpdateRentalAsync(Rentals rentals)
    {
        var rental = await context.Rentals.FindAsync(rentals.Id);
        if (rental == null)
        {
            return new  Response<int>("Rental not found", HttpStatusCode.NotFound);
        }

        context.Rentals.Update(rental);
        await context.SaveChangesAsync();
        return new Response<int>(default!, "Rental Updated");
    }
    

    public async Task<Response<int>> DeleteRentalAsync(int id)
    {
        var rental = await context.Rentals.FindAsync(id);
        if (rental == null)
        {
            return new  Response<int>("Rental not found", HttpStatusCode.NotFound);
        }
        context.Rentals.Remove(rental);
        await context.SaveChangesAsync();
        return new Response<int>(default!, "Rental Deleted");
    }
}