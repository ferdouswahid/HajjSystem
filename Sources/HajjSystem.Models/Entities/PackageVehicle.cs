using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HajjSystem.Models.Entities
{
    public class PackageVehicle : BaseEntity
    {
        // Foreign key to Package
        public int PackageId { get; set; }
        [ForeignKey("PackageId")]
        public Package? Package { get; set; }

        // Foreign key to VehicleContract (contract_id)
        public int ContractId { get; set; }
        [ForeignKey("ContractId")]
        public Contract? Contract { get; set; }

        // Foreign key to Season
        public int SeasonId { get; set; }
        [ForeignKey("SeasonId")]
        public Season? Season { get; set; }

        // Foreign key to Company
        public int CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public Company? Company { get; set; }

    
        public int VehicleContractId { get; set; }
        [ForeignKey("VehicleContractId")]
        public VehicleContract? VehicleContract { get; set; }


        public int? VehicleDetailId { get; set; }
        [ForeignKey("VehicleDetailId")]
        public VehicleDetail? VehicleDetail { get; set; }

        // Dates
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        // Cost and price
        public decimal Cost { get; set; }
        public decimal Price { get; set; }
    }
}