using System.ComponentModel.DataAnnotations;

namespace HajjSystem.Models.Models
{
    public class AirlineContractUpdateModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int VendorId { get; set; }
        public VendorModel? Vendor { get; set; }

        [Required]
        public int Seat { get; set; }
        public string? ContractId { get; set; }
        public ContractModel? Contract { get; set; }
        [Required]
        public int CompanyId { get; set; }
        public CompanyModel? Company { get; set; }
        [Required]
        public int SeasonId { get; set; }
        public SeasonModel? Season { get; set; }
    }
}
