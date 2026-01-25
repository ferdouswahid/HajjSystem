using System;

namespace HajjSystem.Models.Models
{
    public class OrderDetailModel
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public OrderModel? Order { get; set; }
        public int PackageId { get; set; }
        public PackageModel? Package { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public decimal NetPrice { get; set; }
        public string? FullName { get; set; }
        public string? Country { get; set; }
        public string? MobileNo { get; set; }
        public string? Email { get; set; }
        public string? PassportNo { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsEnabled { get; set; }
    }
}