using AutoMapper;
using Domain.DTOs.CarDTOs;
using Domain.DTOs.CustomerDTOs;
using Domain.DTOs.BranchsDTOs;
using Domain.DTOs.RentalDTOs;

using Domain.Entities;

namespace Infrastructure.AutoMapper;

public class InfrastructureProfile : Profile
{
    public InfrastructureProfile()
    {
        CreateMap<Car, GetCarDto>();
        CreateMap<CreateCarDto, Car>();
        CreateMap<UpdateCarDto, Car>();
        
        CreateMap<Customers, GetCustomerDto>();
        CreateMap<CreateCustomerDto, Customers>();
        CreateMap<UpdateCustomerDto, Customers>();
        
        CreateMap<Rentals, GetRentalsDto>();
        CreateMap<CreateRentalDto, Rentals>();
        CreateMap<UpdateRentalDto, Rentals>();
        
        CreateMap<Branches, GetBranchsDto>();
        CreateMap<CreateBranchDto, Branches>();
        CreateMap<UpdateBranchDto, Branches>();
    }
}