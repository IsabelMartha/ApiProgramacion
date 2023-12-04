namespace api_programacion_3.DTO;

public class DTOListResponse
{
    public int Page { get; set; }
    
    public int PageSize { get; set; }

    public int NextPage { get; set; }

    public int PrevPage { get; set; }

    public bool HasNextPage { get; set; }

    public bool HasPrevPage { get; set; }

    public int TotalPage { get; set; }

    public int TotalCount { get; set; }

    public List<Object> List { get; set; } = new List<object>();
}