using Domain.ApiResponses;
using Domain.DTOs.RentalDTOs;
using Domain.Filters;
using Infrastructure.Interfaces.IRentalsServices;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]

public class RentalController(IRentalService rental) : IRentalService
{
    [HttpGet]
    public async Task<PagedResponse<List<GetRentalsDto>>> GetRentalsAsync(RentalFilters filters)
    {
        return await   rental.GetRentalsAsync(filters);
    }
    
    [HttpPost]
    public async Task<Response<string>> CreateRentalAsync(CreateRentalDto rentalDto)
    {
        return await   rental.CreateRentalAsync(rentalDto);
    }

    [HttpPut]
    public async Task<Response<string>> UpdateRentalAsync(int id, UpdateRentalDto rentalDto)
    {
        return await   rental.UpdateRentalAsync(id, rentalDto);
    }

    [HttpDelete]
    public async Task<Response<string>> DeleteRentalAsync(int id)
    {
        return await   rental.DeleteRentalAsync(id);
    }
}
