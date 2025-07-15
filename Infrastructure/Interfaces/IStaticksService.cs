using Domain.DTOs.StaticksDTOs;
using Domain.Filters;

namespace WebApi.Interfaces;

public interface IStaticksService
{
    Task<decimal> GetTotalRevenueAsync(DateRentalFilter filter);
    Task<List<SimpleCarLoadDto>> GetCarLoadStatisticsAsync(DateRentalFilter filter);
    Task<List<TopCarDto>> GetTop5CarsSimpleAsync();
}