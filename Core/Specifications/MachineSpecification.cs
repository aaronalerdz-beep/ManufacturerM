using System;
using Core.Entities;

namespace Core.Specifications;

public class MachineSpecification : BaseSpecification<Machine>
{
    public MachineSpecification(SpecParams specParams):base(x=> 
            (string.IsNullOrWhiteSpace(specParams.Search)||x.Name_machine.Contains(specParams.Search)))
    {
        
    }
}
