using System;
using System.Collections.Generic;

namespace CellperNetCore.Models
{
    public partial class EquipmentStatus
    {
        public EquipmentStatus()
        {
            EquipmentReception = new HashSet<EquipmentReception>();
        }

        public int EquipmentStatusId { get; set; }
        public string EquipmentStatusName { get; set; }

        public virtual ICollection<EquipmentReception> EquipmentReception { get; set; }
    }
}
