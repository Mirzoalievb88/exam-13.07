using AutoMapper;
using Domain.DTOs.CarDTOs;
using Domain.Entities;

namespace Infrastructure.Mappers;

public static class CarMapper
{
    public static Car ToEntity(this CreateCarDto carDto)
    {
        return new Car()
        {
            Model = carDto.Model,
            MAnufacturer = carDto.Manufacturer,
            Year = carDto.Year,
            PricePerDay = carDto.PricePerDay,
        };
    }

    public static void ToEntity(this Car car, UpdateCarDto carDto)
    {
        car.Model = carDto.Model;
        car.MAnufacturer = carDto.Manufacturer;
        car.Year = carDto.Year;
        car.PricePerDay = carDto.PricePerDay;
    }
}