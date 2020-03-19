using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CellperNetCore.Models
{
    public partial class Customer
    {
        public Customer()
        {
            EquipmentReception = new HashSet<EquipmentReception>();
        }

        public int CustomerId { get; set; }

        [Required]
        [DisplayName("Cedula")]
        public int CustomerIdcard { get; set; }

        [Required]
        [DisplayName("Nombre Cliente")]
        public string CustomerName { get; set; }

        [Required]
        [DisplayName("N° de Teléfono")]
        public string CustomerPhone { get; set; }

        [DisplayName("Dirección")]
        public string CustomerAddress { get; set; }

        [Required]
        [DisplayName("Email")]
        public string CustomerEmail { get; set; }

        public virtual ICollection<EquipmentReception> EquipmentReception { get; set; }
    }
}
