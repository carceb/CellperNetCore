using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CellperNetCore.Models
{
    public partial class EquipmentReception
    {
        public int EquipmentReceptionId { get; set; }

        [DisplayName("Accesorios")]
        public string Accesories { get; set; }
        public string Imei { get; set; }
        public string Serial { get; set; }

        [DisplayName("Observaciones")]
        public string Observations { get; set; }

        [Required]
        [DisplayName("Costo presupuesto")]
        public double BudgetCost { get; set; }
        public DateTime ReceptionDate { get; set; }
        
        [Required]
        [DisplayName("Cliente")]
        public int CustomerId { get; set; }

        [Required]
        [DisplayName("Condición")]
        public int EquipmentConditionId { get; set; }

        [Required]
        [DisplayName("Modelo")]
        public int EquipmentModelId { get; set; }

        public int EquipmentStatusId { get; set; }

        [Required]
        [DisplayName("Tipo de falla")]
        public int FailureTypeId { get; set; }

        [Required]
        [DisplayName("Técnico")]
        public int TechnicianId { get; set; }

        [Required]
        [DisplayName("En garantía")]
        public int WarrantyId { get; set; }
        public int LocationId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual EquipmentCondition EquipmentCondition { get; set; }
        public virtual EquipmentModel EquipmentModel { get; set; }
        public virtual EquipmentStatus EquipmentStatus { get; set; }
        public virtual FailureType FailureType { get; set; }
        public virtual Location Location { get; set; }
        public virtual Technician Technician { get; set; }
        public virtual Warranty Warranty { get; set; }
    }
}
