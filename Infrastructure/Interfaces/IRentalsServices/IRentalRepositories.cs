using Domain.ApiResponses;
using Domain.DTOs.RentalDTOs;
using Domain.Entities;
using Domain.Filters;

namespace Infrastructure.Interfaces.IRentalsServices;

public interface IRentalRepositories
{
    Task<PagedResponse<List<Rentals>>> GetAllRentalsAsync(RentalFilters filters);
    Task<Response<int>> CreateRentalAsync(Rentals rentals);
    Task<Response<int>> UpdateRentalAsync(Rentals rentals);
    Task<Response<int>> DeleteRentalAsync(int id);
}