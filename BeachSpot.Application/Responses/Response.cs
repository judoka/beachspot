namespace BeachSpot.Application.Responses;

public class Response<T> where T : class
{
    public Response() { }
    public T? Data { get; set; }
    public bool IsSuccess { get; set; }
    public List<string> Errors { get; }
    public bool IsNotSuccess => !IsSuccess;
    public Status Status { get; set; }

    public Response(Status status, bool isSuccess, T data, List<string> errors)
    {
        Status = status;
        IsSuccess = isSuccess;
        Data = data;

        if (errors != null && errors.Exists(s => !string.IsNullOrWhiteSpace(s)))
        {
            Errors = errors;
        }
    }

    /// <summary>
    /// Ok response
    /// </summary>
    /// <param name="data">Data to be passed</param>
    public Response(T data) : this(Status.OK, true, data, null) { }


    /// <summary>
    /// Error response
    /// </summary>
    /// <param name="status"></param>
    /// <param name="isSuccess"></param>
    /// <param name="error"></param>
    public Response(Status status, List<string> errors) : this(status, false, null, errors) { }

    public static Response<T> Ok(T data) => new(data);
    public static Response<T> Empty(string resource) => new(Status.EMPTY_RESULT, new List<string> { $"Resource '{resource}' not found!" });
    public static Response<T> ValidationFailed(List<string> errors) => new(Status.VALIDATION_FAILED, errors);
    public static Response<T> ValidationFailed(string error) => ValidationFailed(new List<string> { error });
}
