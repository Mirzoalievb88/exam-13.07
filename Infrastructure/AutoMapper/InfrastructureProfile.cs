using AutoMapper;
using Domain.DTOs.BranchsDTOs;
using Domain.DTOs.CarDTOs;
using Domain.DTOs.CustomerDTOs;
using Domain.DTOs.RentalDTOs;
using Domain.Entities;

namespace Infrastructure.AutoMapper;

public class InfrastructureProfile : Profile
{
    public InfrastructureProfile()
    {
        CreateMap<Car, CreateCarDto>().ReverseMap();
        CreateMap<Car, GetCarDto>().ReverseMap();
        CreateMap<Car, UpdateCarDto>().ReverseMap();

        CreateMap<Customers, CreateCustomerDto>().ReverseMap();
        CreateMap<Customers, GetCustomerDto>().ReverseMap();
        CreateMap<Customers, UpdateCustomerDto>().ReverseMap();

        CreateMap<Branches, CreateBranchDto>().ReverseMap();
        CreateMap<Branches, GetBranchsDto>().ReverseMap();
        CreateMap<Branches, UpdateBranchDto>().ReverseMap();

        CreateMap<Rentals, CreateRentalDto>().ReverseMap();
        CreateMap<Rentals, GetRentalsDto>().ReverseMap();

    }
}