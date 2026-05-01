using System;
using Core.DTOs;
using Core.Entities;

namespace Core.Specifications;

public class CycleSpecification : BaseSpecification<Cycle, CycleDto>
{
    public CycleSpecification(SpecParams specParams)
        : base(x => true)
    {
        
    }
}
