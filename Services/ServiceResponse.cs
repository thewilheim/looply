using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace looply.Services
{
    public class ServiceResponse<T>
    {
    public T? Data { get; set; }
    public string? ErrorMessage { get; set; }
    public bool Success => string.IsNullOrEmpty(ErrorMessage); // True if no error

    public static ServiceResponse<T> SuccessResponse(T data)
    {
        return new ServiceResponse<T> { Data = data };
    }

    public static ServiceResponse<T> ErrorResponse(string errorMessage)
    {
        return new ServiceResponse<T> { ErrorMessage = errorMessage };
    }
    }
}