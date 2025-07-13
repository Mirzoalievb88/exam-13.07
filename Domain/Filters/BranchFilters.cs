using Domain.Paginations;

namespace Domain.Filters;

public class BranchFilters : ValidFilter
{
    public string? Name { get; set; }
}