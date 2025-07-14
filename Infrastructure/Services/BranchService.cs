using System.Net;
using AutoMapper;
using Domain.ApiResponses;
using Domain.DTOs.BranchsDTOs;
using Domain.Entities;
using Domain.Filters;
using Domain.Paginations;
using Infrastructure.Data;
using Infrastructure.Interfaces.IBranchServices;
using Infrastructure.Mappers;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.Branchs;

public class BranchService
    (DataContext context,
        IBranchRepositories branchRepositories,
        IMapper  mapper) : IBranchService
{
    public async Task<PagedResponse<List<GetBranchsDto>>> GetAllBranchsAsync(BranchFilters filters)
    {
        var validFilter = new ValidFilter(filters.PageNumber, filters.PageSize);
        var query = context.Branches.AsQueryable();

        if (!string.IsNullOrEmpty(filters.Name))
        {
            query = query.Where(x => x.Name.Contains(filters.Name));
        }

        var totalRecords = await query.CountAsync();
        var paged = await query
            .Skip((filters.PageNumber - 1) * filters.PageSize)
            .Take(filters.PageSize)
            .ToListAsync();
        var branchs = mapper.Map<List<GetBranchsDto>>(paged);
        return new PagedResponse<List<GetBranchsDto>>(branchs, totalRecords, validFilter.PageNumber, validFilter.PageSize);
    }

    public async Task<Response<string>> CreateBranchAsync(CreateBranchDto branchDto)
    {
        var branch = BranchMapper.ToEntity(branchDto);
        var result = await branchRepositories.CreateBranchAsync(branch);
        if (result == null!)
        {
            return new Response<string>("Error", HttpStatusCode.InternalServerError);
        }

        return new Response<string>(default!, "All Worked");
    }

    public async Task<Response<string>> UpdateBranchAsync(int id, UpdateBranchDto branchDto)
    {
        var branch = await context.Branches.FindAsync(id);
        if (branch == null)
        {
            return new Response<string>("Error", HttpStatusCode.NotFound);
        }
        
        branch.ToEntity(branchDto);
        var result = await context.SaveChangesAsync();
        
        return result == 0
            ? new Response<string>("Error", HttpStatusCode.InternalServerError)
            :new Response<string>(default!, "All Worked");
    }

    public async Task<Response<string>> DeleteBranchAsync(int id)
    {
        var branch = await context.Branches.FindAsync(id);
        if (branch == null)
        {
            return new Response<string>("Error", HttpStatusCode.NotFound);
        }
        
        context.Branches.Remove(branch);
        var result = await context.SaveChangesAsync();
        
        return result == 0
            ? new Response<string>("Error", HttpStatusCode.InternalServerError)
            : new Response<string>(default!, "All Worked");
    }
}