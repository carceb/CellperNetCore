using System;
using System.Collections.Generic;

namespace CellperNetCore.Models
{
    public partial class EquipmentModel
    {
        public EquipmentModel()
        {
            EquipmentReception = new HashSet<EquipmentReception>();
        }

        public int EquipmentModelId { get; set; }
        public string EquipmentModelName { get; set; }
        public int? EquipmentBrandId { get; set; }
        public int? EquipmentTypeId { get; set; }

        public virtual EquipmentBrand EquipmentBrand { get; set; }
        public virtual EquipmentType EquipmentType { get; set; }
        public virtual ICollection<EquipmentReception> EquipmentReception { get; set; }
    }
}
