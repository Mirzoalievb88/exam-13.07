using Domain.ApiResponses;
using Domain.DTOs.CustomerDTOs;
using Domain.Filters;

namespace Infrastructure.Interfaces.ICustomerServices;

public interface ICustomerRepositories
{
    Task<PagedResponse<List<GetCustomerDto>>> GetAllCustomersAsync(CustomerFilters filters);
    Task<Response<int>> CreateCustomerAsync(CreateCustomerDto customerDto);
    Task<Response<int>> UpdateCustomerAsync(int id, UpdateCustomerDto customerDto);
    Task<Response<int>> DeleteCustomerAsync(int id);
}