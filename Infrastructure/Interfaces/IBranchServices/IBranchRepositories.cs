using Domain.ApiResponses;
using Domain.DTOs.BranchsDTOs;
using Domain.Filters;

namespace Infrastructure.Interfaces.IBranchServices;

public interface IBranchRepositories
{
    Task<PagedResponse<List<GetBranchsDto>>> GetAllBranchsAsync(BranchFilters filters);
    Task<Response<int>> CreateBranchAsync(CreateBranchDto branchDto);
    Task<Response<int>> UpdateBranchAsync(int id, UpdateBranchDto branchDto);
    Task<Response<int>> DeleteBranchAsync(int id);
}