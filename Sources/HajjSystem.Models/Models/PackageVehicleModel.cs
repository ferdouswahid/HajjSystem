using System;

namespace HajjSystem.Models.Models
{
    public class PackageVehicleModel
    {
        public int Id { get; set; }
        public int PackageId { get; set; }
        public PackageModel? Package { get; set; }
        public int ContractId { get; set; }
        public ContractModel? Contract { get; set; }
        public int SeasonId { get; set; }
        public SeasonModel? Season { get; set; }
        public int CompanyId { get; set; }
        public CompanyModel? Company { get; set; }
        public int VehicleContractId { get; set; }
        public VehicleContractModel? VehicleContract { get; set; }
        public int? VehicleDetailId { get; set; }
        public VehicleDetailModel? VehicleDetail { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Cost { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsEnabled { get; set; }
    }
}