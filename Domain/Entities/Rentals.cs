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
    
    public Car? Car { get; set; }         // ✅ правильно
    public Customers? Customer { get; set; }
    public Branches? Branch { get; set; }
}