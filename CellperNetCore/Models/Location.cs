using System;
using System.Collections.Generic;

namespace CellperNetCore.Models
{
    public partial class Location
    {
        public Location()
        {
            EquipmentReception = new HashSet<EquipmentReception>();
            MaterialInventory = new HashSet<MaterialInventory>();
            SecurityUser = new HashSet<SecurityUser>();
        }

        public int LocationId { get; set; }
        public int TenantId { get; set; }
        public string LocationName { get; set; }
        public string LocationPhone { get; set; }
        public string LocationEmail { get; set; }
        public string LocationAddress { get; set; }

        public virtual Tenant Tenant { get; set; }
        public virtual ICollection<EquipmentReception> EquipmentReception { get; set; }
        public virtual ICollection<MaterialInventory> MaterialInventory { get; set; }
        public virtual ICollection<SecurityUser> SecurityUser { get; set; }
    }
}
