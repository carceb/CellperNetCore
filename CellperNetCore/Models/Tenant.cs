using System;
using System.Collections.Generic;

namespace CellperNetCore.Models
{
    public partial class Tenant
    {
        public Tenant()
        {
            Location = new HashSet<Location>();
            Technician = new HashSet<Technician>();
        }

        public int TenantId { get; set; }
        public string TenantRif { get; set; }
        public string TenantName { get; set; }
        public string TenantAddress { get; set; }
        public string TenantEmail { get; set; }
        public string TenanPhone { get; set; }
        public int CountryId { get; set; }

        public virtual ICollection<Location> Location { get; set; }
        public virtual ICollection<Technician> Technician { get; set; }
    }
}
