using Domain.ApiResponses;
using Domain.DTOs.CustomerDTOs;
using Domain.Filters;
using Infrastructure.Interfaces.ICustomerServices;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]

public class CustomerController(ICustomerService customer) : ICustomerService
{
    [HttpGet]
    public async Task<PagedResponse<List<GetCustomerDto>>> GetAllCustomersAsync(CustomerFilters filters)
    {
        return await customer.GetAllCustomersAsync(filters);
    }
    
    [HttpPost]
    public async Task<Response<string>> CreateCustomerAsync(UpdateCustomerDto customerDto)
    {
        return await  customer.CreateCustomerAsync(customerDto);
    }

    [HttpPut]
    public async Task<Response<string>> UpdateCustomerAsync(int id, UpdateCustomerDto customerDto)
    {
        return await customer.UpdateCustomerAsync(id, customerDto);
    }

    [HttpDelete]
    public async Task<Response<string>> DeleteCustomerAsync(int id)
    {
        return await  customer.DeleteCustomerAsync(id);
    }
}