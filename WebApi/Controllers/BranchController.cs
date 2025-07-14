using Domain.ApiResponses;
using Domain.DTOs.BranchsDTOs;
using Domain.Filters;
using Infrastructure.Interfaces.IBranchServices;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]

public class BranchController(IBranchService branchService) : IBranchService
{
    [HttpGet]
    public async Task<PagedResponse<List<GetBranchsDto>>> GetAllBranchsAsync(BranchFilters filters)
    {
        return await  branchService.GetAllBranchsAsync(filters);
    }
    
    [HttpPost]
    public async Task<Response<string>> CreateBranchAsync(CreateBranchDto branchDto)
    {
        return await  branchService.CreateBranchAsync(branchDto);
    }

    [HttpPut]
    public async Task<Response<string>> UpdateBranchAsync(int id, UpdateBranchDto branchDto)
    {
        return await  branchService.UpdateBranchAsync(id, branchDto);
    }
    
    [HttpDelete]
    public async Task<Response<string>> DeleteBranchAsync(int id)
    {
        return await   branchService.DeleteBranchAsync(id);
    }
}