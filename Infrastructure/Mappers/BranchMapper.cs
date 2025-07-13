using AutoMapper;
using Domain.DTOs.BranchsDTOs;
using Domain.Entities;

namespace Infrastructure.Mappers;

public static class BranchMapper
{
    public static Branches ToEntity(this CreateBranchDto createBranchDto)
    {
        return new Branches()
        {
            Name = createBranchDto.Name,
            Location = createBranchDto.Location,
        };
    }

    public static void ToEntity(this Branches branches, UpdateBranchDto updateBranchDto)
    {
        branches.Name = updateBranchDto.Name;
        branches.Location = updateBranchDto.Location;
    }
}