using System;
using System.Collections.Generic;

namespace CellperNetCore.Models
{
    public partial class SecurityUser
    {
        public int SecurityUserId { get; set; }
        public string SecurityUserLogin { get; set; }
        public string SecurityUserPassword { get; set; }
        public string SecurityUserName { get; set; }
        public int LocationId { get; set; }

        public virtual Location Location { get; set; }
    }
}
