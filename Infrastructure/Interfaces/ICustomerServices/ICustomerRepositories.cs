using Domain.ApiResponses;
using Domain.DTOs.CustomerDTOs;
using Domain.Entities;
using Domain.Filters;

namespace Infrastructure.Interfaces.ICustomerServices;

public interface ICustomerRepositories
{
    Task<PagedResponse<List<Customers>>> GetAllCustomersAsync(CustomerFilters filters);
    Task<Response<int>> CreateCustomerAsync(Customers customers);
    Task<Response<int>> UpdateCustomerAsync(Customers customers);
    Task<Response<int>> DeleteCustomerAsync(int id);
}