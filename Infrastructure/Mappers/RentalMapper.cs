using Domain.DTOs.RentalDTOs;
using Domain.Entities;

namespace Infrastructure.Mappers;

public static class RentalMapper
{
    public static Rentals ToEntity(this CreateRentalDto createRentalDto)
    {
        return new Rentals
        {
            CarId = createRentalDto.CarId,
            CustomerId = createRentalDto.CustomerId,
            BranchId = createRentalDto.BranchId,
            StartDate = createRentalDto.StartDate,
            EndDate = createRentalDto.EndDate,
            ToTalCost = createRentalDto.TotalCost
        };
    }

    public static void ToEntity(this UpdateRentalDto updateRentalDto, Rentals rentals)
    {
        rentals.CarId = updateRentalDto.CarId;
        rentals.CustomerId = updateRentalDto.CustomerId;
        rentals.BranchId = updateRentalDto.BranchId;
        rentals.StartDate = updateRentalDto.StartDate;
        rentals.EndDate = updateRentalDto.EndDate;
        rentals.ToTalCost = updateRentalDto.TotalCost;
    }
}