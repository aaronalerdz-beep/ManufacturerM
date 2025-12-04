using System;
using Core.Entities;

namespace Core.Specifications;

public class PartSpecification : BaseSpecification<Parts>
{
    public PartSpecification(string? material, string? sort):base(x=> 
             string.IsNullOrWhiteSpace(material)|| x.Material ==material)
    {
        switch (sort)
        {
            case "weightAsc":
                AddOrderBy(x => x.Weight);
                break;
            case "weightDesc":
                AddOrderByDescending(x => x.Weight);
                break;
            default:
                AddOrderBy(x => x.IdSeq);
                break;
        }
    }

}
