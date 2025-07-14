using System.Net;
using Domain.ApiResponses;
using Domain.DTOs.CustomerDTOs;
using Domain.Entities;
using Domain.Filters;
using Domain.Paginations;
using Infrastructure.Data;
using Infrastructure.Interfaces.ICustomerServices;

namespace Infrastructure.Repositories;

public class CustomerRepositories(DataContext context) : ICustomerRepositories
{
    public async Task<PagedResponse<List<Customers>>> GetAllCustomersAsync(CustomerFilters filters)
    {
        var customer = context.Customers.AsQueryable();

        if (!string.IsNullOrEmpty(filters.FullName))
        {
            customer = customer.Where(c => c.FullName.Contains(filters.FullName));            
        }

        var pagination = new Pagination<Customers>(customer);
        return await pagination.GetPagedResponseAsync(filters.PageNumber, filters.PageSize);
    }

    public async Task<Response<int>> CreateCustomerAsync(Customers customers)
    {
        await context.Customers.AddAsync(customers);
        await context.SaveChangesAsync();
        return new Response<int>(default!, "All Worked");
    }

    public async Task<Response<int>> UpdateCustomerAsync(Customers customers)
    {
        var customer = await context.Customers.FindAsync(customers.Id);
        if (customer == null)
        {
            return new Response<int>("Error", HttpStatusCode.NotFound);
        }
        
        context.Update(customer);
        await context.SaveChangesAsync();
        
        return new Response<int>(default!, "All Worked");
    }

    public async Task<Response<int>> DeleteCustomerAsync(int id)
    {
        var customer = await context.Customers.FindAsync(id);
        if (customer == null)
        {
            return new Response<int>("Error", HttpStatusCode.NotFound);
        }
        context.Customers.Remove(customer);
        await context.SaveChangesAsync();
        return new Response<int>(default!, "All Worked");
    }
}