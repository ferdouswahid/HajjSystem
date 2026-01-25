using System.ComponentModel.DataAnnotations.Schema;

namespace HajjSystem.Models.Entities
{
    public class PackageAirline : BaseEntity
    {
        // Foreign key to Package
        public int PackageId { get; set; }
        [ForeignKey("PackageId")]
        public Package? Package { get; set; }

        // Foreign key to AirlineContract (contract_id)
        public int ContractId { get; set; }
        [ForeignKey("ContractId")]
        public Contract? Contract { get; set; }

        // Foreign key to Company
        public int CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public Company? Company { get; set; }

        // Foreign key to AirlineContractDetail
        public int AirlineContractDetailId { get; set; }
        [ForeignKey("AirlineContractDetailId")]
        public AirlineContractDetail? AirlineContractDetail { get; set; }

        // Cost and price
        public decimal Cost { get; set; }
        public decimal Price { get; set; }

        // Foreign key to Season
        public int SeasonId { get; set; }
        [ForeignKey("SeasonId")]
        public Season? Season { get; set; }
    }
}