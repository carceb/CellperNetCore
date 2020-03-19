using System;
using System.Collections.Generic;

namespace CellperNetCore.Models
{
    public partial class EquipmentRepair
    {
        public int EquipmentRepairId { get; set; }
        public int MaterialQuantityUsed { get; set; }
        public string Observations { get; set; }
        public DateTime RepairDate { get; set; }
        public int MaterialsInventoryId { get; set; }
        public int TechnicianId { get; set; }

        public virtual MaterialInventory MaterialsInventory { get; set; }
        public virtual Technician Technician { get; set; }
    }
}
