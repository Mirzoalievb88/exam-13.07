namespace Domain.Entities;

public class Rentals
{
    public int Id { get; set; }
    public int CarId { get; set; }
    public int CustomerId { get; set; }
    public int BranchId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal ToTalCost { get; set; }
    
    //navigations
    
    public Customers? Car { get; set; } 
    public Customers? Customer { get; set; }
}