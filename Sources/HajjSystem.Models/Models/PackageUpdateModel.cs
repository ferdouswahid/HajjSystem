using System;
using System.ComponentModel.DataAnnotations;

namespace HajjSystem.Models.Models
{
    public class PackageUpdateModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; } = string.Empty;
        [Required]
        public int PackageTypeId { get; set; }

        [Required]
        public decimal TotalCost { get; set; }
        [Required]
        public decimal TotalPrice { get; set; }
        [Required]
        public decimal Discount { get; set; }
        [Required]
        public decimal NetPrice { get; set; }
        [Required]
        public int TotalNoOfNight { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public int NoOfPilgrim { get; set; }
        [Required]
        public int CompanyId { get; set; }
        [Required]
        public int SeasonId { get; set; }
        public List<PackageVehicleUpdateModel>? PackageVehicles { get; set; }
    }
}