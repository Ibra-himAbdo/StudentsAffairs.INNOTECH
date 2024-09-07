namespace StudentsAffairs.INNOTECH.Core.Specifications;

public class SpecificationParams
{
    const int MaxPageSize = 10;
    private int _pageSize = 5;

    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = value > MaxPageSize ? MaxPageSize : value;
    }

    public int PageIndex { get; set; } = 1;
    public string? Sort { get; set; }

    private string? _search;

    public string? Search
    {
        get => _search;
        set => _search = value?.ToLowerInvariant();
    }
}
