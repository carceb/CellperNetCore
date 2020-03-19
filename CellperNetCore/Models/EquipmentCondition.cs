using System;
using System.Collections.Generic;

namespace CellperNetCore.Models
{
    public partial class EquipmentCondition
    {
        public EquipmentCondition()
        {
            EquipmentReception = new HashSet<EquipmentReception>();
        }

        public int EquipmentConditionId { get; set; }
        public string EquipmentConditionName { get; set; }

        public virtual ICollection<EquipmentReception> EquipmentReception { get; set; }
    }
}
