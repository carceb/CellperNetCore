using System;
using System.Collections.Generic;

namespace CellperNetCore.Models
{
    public partial class Warranty
    {
        public Warranty()
        {
            EquipmentReception = new HashSet<EquipmentReception>();
        }

        public int WarrantyId { get; set; }
        public string WarrantyName { get; set; }

        public virtual ICollection<EquipmentReception> EquipmentReception { get; set; }
    }
}
