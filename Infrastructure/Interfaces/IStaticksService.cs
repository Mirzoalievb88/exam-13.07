using Domain.Filters;

namespace WebApi.Interfaces;

public interface IStaticksService
{
    Task<decimal> GetTotalRevenueAsync(DateRentalFilter filter);
    Task<List<CarLoadDto>> GetCarLoadStatisticsAsync(DateRangeFilter filter)
}