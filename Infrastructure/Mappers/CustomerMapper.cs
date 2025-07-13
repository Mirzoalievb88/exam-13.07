using Domain.DTOs.CustomerDTOs;
using Domain.Entities;

namespace Infrastructure.Mappers;

public static class CustomerMapper
{
    public static Customers ToEntity(this CreateCustomerDto  customerDto)
    {
        return new Customers()
        {
            FullName = customerDto.FullName,
            Phone = customerDto.Phone,
            Email = customerDto.Email,
        };
    }

    public static void ToEntity(this Customers customers, UpdateCustomerDto customerDto)
    {
        customers.FullName = customerDto.FullName;
        customers.Phone = customerDto.Phone;
        customers.Email = customerDto.Email;
    }
}