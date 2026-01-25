using System.ComponentModel.DataAnnotations.Schema;

namespace HajjSystem.Models.Entities
{
    public class OrderDetail : BaseEntity
    {
        // Foreign key to Order
        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public Order? Order { get; set; }

        // Foreign key to Package
        public int PackageId { get; set; }
        [ForeignKey("PackageId")]
        public Package? Package { get; set; }

        // Pricing
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public decimal NetPrice { get; set; }

        // Personal info
        public string? FullName { get; set; }
        public string? Country { get; set; }
        public string? MobileNo { get; set; }
        public string? Email { get; set; }
        public string? PassportNo { get; set; }
    }
}