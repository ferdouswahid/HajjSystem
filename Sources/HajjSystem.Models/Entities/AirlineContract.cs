using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HajjSystem.Models.Entities
{
    public class AirlineContract : BaseEntity
    {
        
        // Foreign key to Vendor
        public int VendorId { get; set; }
        [ForeignKey("VendorId")]
        public Vendor? Vendor { get; set; }

        // Agreed seat count
        public int Seat { get; set; }

        // Contract identifier (string or int, assuming string for flexibility)
        public int? ContractId { get; set; }

        [ForeignKey("ContractId")]
        public Contract? Contract { get; set; }

        // Foreign key to Company
        public int CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public Company? Company { get; set; }

        // Foreign key to Season
        public int SeasonId { get; set; }
        [ForeignKey("SeasonId")]
        public Season? Season { get; set; }
        
        public ICollection<AirlineContractDetail>? AirlineContractDetails { get; set; }
        public ICollection<PackageAirline>? PackageAirlines { get; set; }
    }
}