using System;

namespace Core.Entities;

public class Cycle : BaseEntity
{
    public int parts_per_cycle { get; set; }
    public int finished { get; set; }
    public Machine_config? MachineConfig { get; set; }
    public int MachineConfIdSeq { get; set; }
    public Production_order? ProductionOrder { get; set; }
    public int ProductionOrderIdSeq { get; set; }
}
