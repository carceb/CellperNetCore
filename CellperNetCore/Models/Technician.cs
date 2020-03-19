using System;
using System.Collections.Generic;

namespace CellperNetCore.Models
{
    public partial class Technician
    {
        public Technician()
        {
            EquipmentReception = new HashSet<EquipmentReception>();
            EquipmentRepair = new HashSet<EquipmentRepair>();
        }

        public int TechnicianId { get; set; }
        public string TechnicianName { get; set; }
        public int TenantId { get; set; }

        public virtual Tenant Tenant { get; set; }
        public virtual ICollection<EquipmentReception> EquipmentReception { get; set; }
        public virtual ICollection<EquipmentRepair> EquipmentRepair { get; set; }
    }
}
