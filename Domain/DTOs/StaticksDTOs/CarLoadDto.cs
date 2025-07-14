namespace Domain.DTOs.StaticksDTOs;

public class CarLoadDto
{
    public int CarId { get; set; }
    public string? Model { get; set; }
    public string? Manufacturer { get; set; }
    public double BusyDays { get; set; }
    public double TotalPeriodDays { get; set; }
    public double LoadPercent { get; set; }
}