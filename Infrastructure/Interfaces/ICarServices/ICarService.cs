using Domain.ApiResponses;
using Domain.DTOs.CarDTOs;
using Domain.Filters;

namespace Infrastructure.Interfaces.ICarServices;

public interface ICarService
{
    Task<PagedResponse<List<GetCarDto>>> GetAllCarsAsync(CarFilters filters);
    Task<Response<string>> CreateCarAsync(CreateCarDto carDto);
    Task<Response<string>> UpdateCarAsync(int id, UpdateCarDto carDto);
    Task<Response<string>> DeleteCarAsync(int id);
}