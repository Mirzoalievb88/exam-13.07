using Domain.ApiResponses;
using Domain.DTOs.BranchsDTOs;
using Domain.Entities;
using Domain.Filters;

namespace Infrastructure.Interfaces.IBranchServices;

public interface IBranchRepositories
{
    Task<PagedResponse<List<Branches>>> GetAllBranchsAsync(BranchFilters filters);
    Task<Response<int>> CreateBranchAsync(Branches branches);
    Task<Response<int>> UpdateBranchAsync(Branches branches);
    Task<Response<int>> DeleteBranchAsync(int id);
}