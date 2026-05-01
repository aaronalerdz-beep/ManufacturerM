

namespace Core.DTOs;

public class CycleDto
{
    public int IdSeq { get; set; }
    public int parts_per_cycle { get; set; }
    public int finished { get; set; }
    public int MachineConfIdSeq { get; set; }
    public int ProductionOrderIdSeq { get; set; }   
    public double Pressure { get; set; }
}