namespace OnqueteApi.Types;

public class AppResponse<T>
{
    public string Status { get; set; } = String.Empty;
    public string Message { get; set; } = String.Empty;
    public T Data { get; set; }
}