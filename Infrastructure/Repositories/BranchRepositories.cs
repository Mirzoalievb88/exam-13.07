using System.Net;
using Domain.ApiResponses;
using Domain.DTOs.BranchsDTOs;
using Domain.Entities;
using Domain.Filters;
using Domain.Paginations;
using Infrastructure.Data;
using Infrastructure.Interfaces.IBranchServices;

namespace Infrastructure.Repositories;

public class BranchRepositories(DataContext context) : IBranchRepositories
{
    public async Task<PagedResponse<List<Branches>>> GetAllBranchsAsync(BranchFilters filters)
    {
        var query = context.Branches.AsQueryable();

        if (!string.IsNullOrEmpty(filters.Name))
        {
            query = query.Where(x => x.Name.Contains(filters.Name));
        }

        var pagination = new Pagination<Branches>(query);
        return await pagination.GetPagedResponseAsync(filters.PageNumber, filters.PageSize);
    }

    public async Task<Response<int>> CreateBranchAsync(Branches branches)
    {
        await  context.Branches.AddAsync(branches);
        await context.SaveChangesAsync();
        return new Response<int>(default!, "All Worked");
    }

    public async Task<Response<int>> UpdateBranchAsync(Branches branches)
    {
        var branch = await context.Branches.FindAsync(branches.Id);
        if (branch != null)
        {
            return new Response<int>("Branch Updated", HttpStatusCode.NotFound);
        }
        
        context.Branches.Update(branches);
        await context.SaveChangesAsync();
        
        return new Response<int>(default, "Branch Updated");
    }

    public async Task<Response<int>> DeleteBranchAsync(int id)
    {
        var  branch = await context.Branches.FindAsync(id);
        if (branch != null)
        {
            context.Branches.Remove(branch);
        }

         context.Branches.Remove(branch);
         await context.SaveChangesAsync();
         
         return new Response<int>(default!, "Branch Deleted");
    }
}