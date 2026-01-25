using System.ComponentModel.DataAnnotations;

namespace HajjSystem.Models.Models
{
    public class PackageAirlineUpdateModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int PackageId { get; set; }
        public PackageModel? Package { get; set; }

        [Required]
        public int ContractId { get; set; }
        public ContractModel? Contract { get; set; }

        [Required]
        public int CompanyId { get; set; }
        public CompanyModel? Company { get; set; }

        [Required]
        public int AirlineContractDetailId { get; set; }
        public AirlineContractDetailModel? AirlineContractDetail { get; set; }

        [Required]
        public decimal Cost { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int SeasonId { get; set; }
        public SeasonModel? Season { get; set; }
    }
}