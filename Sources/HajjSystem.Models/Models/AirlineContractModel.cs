using System;

namespace HajjSystem.Models.Models
{
    public class AirlineContractModel
    {
        public int Id { get; set; }
        public int VendorId { get; set; }

        public VendorModel? Vendor { get; set; }

        public int Seat { get; set; }
        public string? ContractId { get; set; }
        public ContractModel? Contract { get; set; }
        public int CompanyId { get; set; }
        public CompanyModel? Company { get; set; }
        public int SeasonId { get; set; }
        public SeasonModel? Season { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsEnabled { get; set; }
    }
}
