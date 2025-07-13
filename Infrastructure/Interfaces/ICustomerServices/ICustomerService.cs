using Domain.ApiResponses;
using Domain.DTOs.CustomerDTOs;
using Domain.Filters;

namespace Infrastructure.Interfaces.ICustomerServices;

public interface ICustomerService
{
    Task<PagedResponse<List<GetCustomerDto>>> GetAllCustomersAsync(CustomerFilters filters);
    Task<Response<string>> CreateCustomerAsync(UpdateCustomerDto customerDto);
    Task<Response<string>> UpdateCustomerAsync(int id, UpdateCustomerDto customerDto);
    Task<Response<string>> DeleteCustomerAsync(int id);
}