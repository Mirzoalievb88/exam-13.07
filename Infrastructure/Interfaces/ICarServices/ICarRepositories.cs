using Domain.ApiResponses;
using Domain.DTOs.CarDTOs;
using Domain.Entities;
using Domain.Filters;

namespace Infrastructure.Interfaces.ICarServices;

public interface ICarRepositories
{
    Task<PagedResponse<List<Car>>> GetAllAsync(CarFilters filter);
    Task<Response<int>> CreateCarAsync(Car car);
    Task<Response<int>> UpdateCarAsync(Car car);
    Task<Response<int>> DeleteCarAsync(int id);
}