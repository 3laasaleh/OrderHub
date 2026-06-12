namespace OrderHub.Application.DTOs
{
    public sealed class ProcessOrderResult
{
    public bool Success { get; init; }
    public string Message { get; init; } = string.Empty;
    public decimal? Subtotal { get; init; }

    public static ProcessOrderResult Ok(decimal subtotal)
        => new()
        {
            Success = true,
            Message = "OK",
            Subtotal = subtotal
        };

    public static ProcessOrderResult Fail(string message)
        => new()
        {
            Success = false,
            Message = message
        };
}
}