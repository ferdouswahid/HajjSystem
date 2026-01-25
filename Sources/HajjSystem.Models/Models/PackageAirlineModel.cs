using System;

namespace HajjSystem.Models.Models
{
    public class PackageAirlineModel
    {
        public int Id { get; set; }
        public int PackageId { get; set; }
        public PackageModel? Package { get; set; }
        public int ContractId { get; set; }
        public ContractModel? Contract { get; set; }
        public int CompanyId { get; set; }
        public CompanyModel? Company { get; set; }
        public int AirlineContractDetailId { get; set; }
        public AirlineContractDetailModel? AirlineContractDetail { get; set; }
        public decimal Cost { get; set; }
        public decimal Price { get; set; }
        public int SeasonId { get; set; }
        public SeasonModel? Season { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsEnabled { get; set; }
    }
}