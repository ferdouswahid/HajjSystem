using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HajjSystem.Models.Entities
{
    public class Package : BaseEntity
    {
        [Required]
        public string Title { get; set; } = string.Empty;

        // Foreign key to PackageType
        public int PackageTypeId { get; set; }
        [ForeignKey("PackageTypeId")]
        public PackageType? PackageType { get; set; }

        // Financials
        public decimal TotalCost { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal NetPrice { get; set; }

        // Duration
        public int TotalNoOfNight { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        // Pilgrims
        public int NoOfPilgrim { get; set; }

        // Foreign key to Company
        public int CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public Company? Company { get; set; }

        // Foreign key to Season
        public int SeasonId { get; set; }
        [ForeignKey("SeasonId")]
        public Season? Season { get; set; }
        
        public ICollection<PackageVehicle>? PackageVehicles { get; set; }
        public ICollection<PackageAirline>? PackageAirlines { get; set; }
        public ICollection<OrderDetail>? OrderDetails { get; set; }
    }
}