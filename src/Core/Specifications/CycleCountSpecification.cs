
using Core.Entities;
using Core.Specifications;

namespace Core.Specifications;

public class CycleCountSpecification 
    : BaseSpecification<Cycle>
{
    public CycleCountSpecification(SpecParams specParams)
        : base(x => true)
    {
        // aquí agregas filtros si existen
    }
}