using System;
using System.Collections.Generic;

namespace CellperNetCore.Models
{
    public partial class FailureType
    {
        public FailureType()
        {
            EquipmentReception = new HashSet<EquipmentReception>();
        }

        public int FailureTypeId { get; set; }
        public string FailureTypeName { get; set; }

        public virtual ICollection<EquipmentReception> EquipmentReception { get; set; }
    }
}
