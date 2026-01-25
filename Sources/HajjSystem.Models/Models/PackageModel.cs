using System;

namespace HajjSystem.Models.Models
{
    public class PackageModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int PackageTypeId { get; set; }
        public PackageTypeModel? PackageType { get; set; }
        public decimal TotalCost { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal NetPrice { get; set; }
        public int TotalNoOfNight { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int NoOfPilgrim { get; set; }
        public int CompanyId { get; set; }
        public CompanyModel? Company { get; set; }
        public int SeasonId { get; set; }
        public SeasonModel? Season { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsEnabled { get; set; }

        public List<PackageVehicleModel>? PackageVehicles { get; set; }
    }
}