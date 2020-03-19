using System;
using System.Collections.Generic;

namespace CellperNetCore.Models
{
    public partial class EquipmentType
    {
        public EquipmentType()
        {
            EquipmentModel = new HashSet<EquipmentModel>();
        }

        public int EquipmentTypeId { get; set; }
        public string EquipmentTypeName { get; set; }

        public virtual ICollection<EquipmentModel> EquipmentModel { get; set; }
    }
}
