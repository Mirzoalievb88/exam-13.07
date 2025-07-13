using Domain.Paginations;

namespace Domain.Filters;

public class RentalFilters : ValidFilter
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}