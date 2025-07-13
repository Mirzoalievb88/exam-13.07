using Domain.Paginations;

namespace Domain.Filters;

public class CustomerFilters : ValidFilter
{
    public string? FullName { get; set; }
}