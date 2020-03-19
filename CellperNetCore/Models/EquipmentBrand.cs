using System;
using System.Collections.Generic;

namespace CellperNetCore.Models
{
    public partial class EquipmentBrand
    {
        public EquipmentBrand()
        {
            EquipmentModel = new HashSet<EquipmentModel>();
        }

        public int EquipmentBrandId { get; set; }
        public string EquipmentBrandName { get; set; }

        public virtual ICollection<EquipmentModel> EquipmentModel { get; set; }
    }
}
