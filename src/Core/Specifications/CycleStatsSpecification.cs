using Core.Entities;
using Core.DTOs;

namespace Core.Specifications;

public class CycleWithDtoSpecification : BaseSpecification<Cycle, CycleDto>
{
    public CycleWithDtoSpecification(SpecParams specParams) 
    {
        AddSelect(x => new CycleDto
        {
            IdSeq = x.IdSeq,
            parts_per_cycle = x.parts_per_cycle,
            finished = x.finished,
            MachineConfIdSeq = x.MachineConfIdSeq,
            ProductionOrderIdSeq = x.ProductionOrderIdSeq,
            Pressure = x.MachineConfig != null ? x.MachineConfig.pressure : 0
        });

    }
}