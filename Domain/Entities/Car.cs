namespace Domain.Entities;

public class Car
{
    public int Id { get; set; }
    public string? Model { get; set; }
    public string? MAnufacturer { get; set; }
    public int Year { get; set; }
    public decimal PricePerDay { get; set; }
    public int? BranchId { get; set; } 
    
    //navigations
    
    public Branches? Branch { get; set; }
    public List<Rentals>? Rentals { get; set; }
}