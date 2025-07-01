namespace clientes_ms.Application.Records.Response;

public class PaginationResponse<T>
{
    public List<T> Items { get; init; } = new();
    public int Page { get; init; }
    public int PageSize { get; init; }
    public int TotalItems { get; init; }
    public int TotalPages => (int)Math.Ceiling((double)TotalItems / PageSize);
    public string? Message { get; init; }

    public PaginationResponse() { }

    public PaginationResponse(List<T> items, int page, int pageSize, int totalItems, string? message = null)
    {
        Items = items;
        Page = page;
        PageSize = pageSize;
        TotalItems = totalItems;
        Message = message;
    }
}
