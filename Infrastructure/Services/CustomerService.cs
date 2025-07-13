using System.Net;
using AutoMapper;
using Domain.ApiResponses;
using Domain.DTOs.CustomerDTOs;
using Domain.Filters;
using Domain.Paginations;
using Infrastructure.Data;
using Infrastructure.Interfaces.ICustomerServices;
using Infrastructure.Mappers;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class CustomerService(
    DataContext context, 
    IMapper mapper, 
    ICustomerRepositories customerRepositories) : ICustomerService
{
    public async Task<PagedResponse<List<GetCustomerDto>>> GetAllCustomersAsync(CustomerFilters filters)
    {
        var validFilter = new ValidFilter(filters.PageNumber, filters.PageSize);
        var query = context.Customers.AsQueryable();
        
        if (!string.IsNullOrEmpty(filters.FullName))
        {
            query = query.Where(c => c.FullName.Contains(filters.FullName));
        }

        var totalRecord = await query.CountAsync();
        
        var paged = await query
            .Skip((filters.PageNumber - 1) * filters.PageSize)
            .Take(filters.PageSize)
            .ToListAsync();
        var customers = mapper.Map<List<GetCustomerDto>>(paged);
        
        return new PagedResponse<List<GetCustomerDto>>(customers, totalRecord, validFilter.PageNumber, validFilter.PageSize);
    }

    public async Task<Response<string>> CreateCustomerAsync(UpdateCustomerDto customerDto)
    {
        var customer = CustomerMapper.ToEntity(customerDto);
        var result = await customerRepositories.CreateCustomerAsync(customerDto);

        if (result == null!)
        {
            return new Response<string>("Error", HttpStatusCode.InternalServerError);
        }

        return new Response<string>(default!, "All Worked");
    }

    public async Task<Response<string>> UpdateCustomerAsync(int id, UpdateCustomerDto customerDto)
    {
        var customer = await context.Customers.FindAsync(id);
        if (customer == null)
        {
            return new Response<string>("Error", HttpStatusCode.NotFound);
        }
        
        customer.ToEntity(customerDto);
        var result = await context.SaveChangesAsync();
        
        return result == 0
            ? new Response<string>("Error", HttpStatusCode.InternalServerError)
            : new Response<string>($"Customer {id} successfully updated", HttpStatusCode.OK);
    }

    public async Task<Response<string>> DeleteCustomerAsync(int id)
    {
        var customer = await context.Customers.FindAsync(id);
        if (customer == null)
        {
            return new Response<string>("Error", HttpStatusCode.NotFound);
        }
        
        context.Customers.Remove(customer);
        var result = await context.SaveChangesAsync();
        
        return result == 0
            ? new Response<string>("Error", HttpStatusCode.InternalServerError)
            : new Response<string>($"Customer {id} successfully deleted", HttpStatusCode.OK); 
    }
}