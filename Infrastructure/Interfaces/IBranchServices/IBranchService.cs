using Domain.ApiResponses;
using Domain.DTOs.BranchsDTOs;
using Domain.Entities;
using Domain.Filters;

namespace Infrastructure.Interfaces.IBranchServices;

public interface IBranchService
{
    Task<PagedResponse<List<GetBranchsDto>>>  GetAllBranchsAsync(BranchFilters filters);
    Task<Response<string>> CreateBranchAsync(CreateBranchDto branchDto);
    Task<Response<string>> UpdateBranchAsync(int id, UpdateBranchDto branchDto);
    Task<Response<string>> DeleteBranchAsync(int id);
}