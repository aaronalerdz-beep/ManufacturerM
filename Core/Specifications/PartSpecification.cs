using System;
using System.ComponentModel;
using Core.Entities;

namespace Core.Specifications;

public class PartSpecification : BaseSpecification<Part>
{
    public PartSpecification(SpecParams specParams):base(x=> 
            (string.IsNullOrWhiteSpace(specParams.Search)||x.Description.ToLower().Contains(specParams.Search))&&
            (!specParams.Materials.Any())|| specParams.Materials.Contains(x.Material))
    {
        ApplyPaging(specParams.PageSize * (specParams.PageIndex -1), specParams.PageSize);
        switch (specParams.Sort)
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
