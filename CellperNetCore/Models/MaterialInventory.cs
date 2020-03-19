using System;
using System.Collections.Generic;

namespace CellperNetCore.Models
{
    public partial class MaterialInventory
    {
        public MaterialInventory()
        {
            EquipmentRepair = new HashSet<EquipmentRepair>();
        }

        public int MaterialInventoryId { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public double Cost { get; set; }
        public string ItemSerial { get; set; }
        public int LocationId { get; set; }

        public virtual Location Location { get; set; }
        public virtual ICollection<EquipmentRepair> EquipmentRepair { get; set; }
    }
}
