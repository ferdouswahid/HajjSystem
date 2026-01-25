using System;
using System.ComponentModel.DataAnnotations;

namespace HajjSystem.Models.Models
{
    public class PackageVehicleCreateModel
    {
     
        public int? PackageId { get; set; }

        [Required]
        public int ContractId { get; set; }

        [Required]
        public int SeasonId { get; set; }

        [Required]
        public int CompanyId { get; set; }

        [Required]
        public int VehicleContractId { get; set; }

        public int? VehicleDetailId { get; set; }
        
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public decimal Cost { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}