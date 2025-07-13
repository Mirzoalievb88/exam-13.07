namespace Domain.Entities;

public class Branches
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Location { get; set; }
    
    //navigations

    public List<Car>? Cars { get; set; }
}