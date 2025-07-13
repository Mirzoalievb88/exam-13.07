using Domain.ApiResponses;
using Domain.DTOs.RentalDTOs;
using Domain.Filters;

namespace Infrastructure.Interfaces.IRentalsServices;

public interface IRentalRepositories
{
    Task<PagedResponse<List<GetRentalsDto>>> GetAllRentalsAsync(RentalFilters filters);
    Task<Response<int>> CreateRentalAsync(CreateRentalDto rentalDto);
    Task<Response<int>> UpdateRentalAsync(int id, UpdateRentalDto rentalDto);
    Task<Response<int>> DeleteRentalAsync(int id);
}