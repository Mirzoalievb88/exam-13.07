using System.Net;

namespace Domain.ApiResponses;

public class Response<T>
{
    public bool IsSuccess { get; set; }
    public T? Data { get; set; }
    public string? Message { get; set; }
    public HttpStatusCode StatusCode { get; set; }

    public Response(string message, HttpStatusCode statusCode)
    {
        IsSuccess = false;
        Data = default;
        Message = message;
        StatusCode = statusCode;
    }

    public Response(T? data, string message)
    {
        IsSuccess = true;
        Data = data;
        Message = message;
        StatusCode = HttpStatusCode.OK;
    }

    protected Response(object data)
    {
        throw new NotImplementedException();
    }
}