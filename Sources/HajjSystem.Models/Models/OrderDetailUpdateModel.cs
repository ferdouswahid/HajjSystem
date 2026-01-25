using System.ComponentModel.DataAnnotations;

namespace HajjSystem.Models.Models
{
    public class OrderDetailUpdateModel
    {
        public int? Id { get; set; }
        [Required]
        public int OrderId { get; set; }
        [Required]
        public int PackageId { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public decimal Discount { get; set; }
        [Required]
        public decimal NetPrice { get; set; }
        public string? FullName { get; set; }
        public string? Country { get; set; }
        public string? MobileNo { get; set; }
        public string? Email { get; set; }
        public string? PassportNo { get; set; }
    }
}