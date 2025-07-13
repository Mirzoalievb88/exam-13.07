using Domain.ApiResponses;
using Domain.DTOs.RentalDTOs;
using Domain.Filters;

namespace Infrastructure.Interfaces.IRentalsServices;

public interface IRentalService
{
    Task<PagedResponse<List<GetRentalsDto>>> GetRentalsAsync(RentalFilters filters);
    Task<Response<string>> CreateRentalAsync(CreateRentalDto rentalDto);
    Task<Response<string>> UpdateRentalAsync(int id, UpdateRentalDto rentalDto);
    Task<Response<string>> DeleteRentalAsync(int id);
}