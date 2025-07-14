using Domain.ApiResponses;
using Domain.DTOs.CarDTOs;
using Domain.Filters;
using Infrastructure.Interfaces.ICarServices;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;


[ApiController]
[Route("api/[controller]")]
public class CarController(ICarService carService) : ICarService
{
    
    [HttpGet]
    public async Task<PagedResponse<List<GetCarDto>>> GetAllCarsAsync(CarFilters filters)
    {
        return await carService.GetAllCarsAsync(filters);
    }

    [HttpPost]
    public async Task<Response<string>> CreateCarAsync(CreateCarDto carDto)
    {
        return await carService.CreateCarAsync(carDto);
    }

    [HttpPut]
    public async Task<Response<string>> UpdateCarAsync(int id, UpdateCarDto carDto)
    {
        return await  carService.UpdateCarAsync(id, carDto);
    }

    [HttpDelete]
    public async Task<Response<string>> DeleteCarAsync(int id)
    {
        return await carService.DeleteCarAsync(id);
    }
}