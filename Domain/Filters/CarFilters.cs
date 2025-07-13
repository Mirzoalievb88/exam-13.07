using Domain.Paginations;

namespace Domain.Filters;

public class CarFilters : ValidFilter
{
    public string? Model { get; set; }
    public decimal? MinPricePerDay { get; set; }
    public decimal? MaxPricePerDay { get; set; }
}