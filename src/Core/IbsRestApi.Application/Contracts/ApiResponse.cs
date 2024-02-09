namespace IbsRestApi.Application.Contracts;

public class ApiResponse<T>
{
    public ApiResponse() { }

    public ApiResponse(T response)
    {
        data = response;
    }

    public T data { get; set; }

    public int statusCode { get; set; } = 200;

    public bool hasError { get; set; } = false;

    public string message { get; set; } = string.Empty;
}
