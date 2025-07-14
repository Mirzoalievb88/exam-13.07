using System.Net;
using Domain.DTOs.BranchsDTOs;
using Domain.DTOs.CarDTOs;
using Domain.DTOs.CustomerDTOs;

namespace Domain.ApiResponses;

public class PagedResponse<T> : Response<T>
{
    public int TotalRecords { get; set; }
    public int TotalPages { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    
    public PagedResponse(T? data, int totalRecords, int pageNumber, int pageSize) : base(data)
    {
        TotalRecords = totalRecords;
        PageNumber = pageNumber;
        PageSize = pageSize;
        TotalPages = (int)Math.Ceiling(totalRecords /(float) pageSize); 
    }

    public PagedResponse(HttpStatusCode statusCode, string message) : base(message, statusCode)
    {
    }
}