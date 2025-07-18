﻿namespace Domain.Entities;

public class Customers
{
    public int Id { get; set; }
    public string? FullName { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    
    //navigations

    public List<Rentals>? Rentals { get; set; }
}