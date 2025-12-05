using System;
using System.Security.Cryptography.X509Certificates;

namespace Core.Specifications;

public class SpecParams
{
    private const int MaxPageSize = 50;

    public int PageIndex {get; set;} = 1;

    private int _pageSize = 6;

    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = (value > MaxPageSize) ? MaxPageSize: value;
    }
    private List<string> _material = [];
    public List<string> Materials
    {
        get => _material;
        set
        {
            _material = value.SelectMany(x => x.Split(',',
            StringSplitOptions.RemoveEmptyEntries)).ToList();
        }
    }
    public string? Sort { get; set;}

    private string? _search;
    public string Search
    {
        get => _search ?? "";
        set => _search = value.ToLower();
    }
}
