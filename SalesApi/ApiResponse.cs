namespace SalesApi;

public class ApiResponse<T>(T? data)
{
    public T? Data { get; set; } = data;
    public string Status { get; set; } = "success";
    public string Message { get; set; } = "Operação concluída com sucesso";
}
