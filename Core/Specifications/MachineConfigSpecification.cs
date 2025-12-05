using System;
using Core.Entities;

namespace Core.Specifications;

public class MachineConfigSpecification: BaseSpecification<Machine_config>
{
    public MachineConfigSpecification(SpecParams specParams ):base(x=> 
            (string.IsNullOrWhiteSpace(specParams.Search)||x.operator_name.Contains(specParams.Search)))
   
    {
        
    }

}
