using System;
using System.ComponentModel.DataAnnotations;
using HajjSystem.Models.Enums;

namespace HajjSystem.Models.Models
{
    public class OrderCreateModel
    {
        [Required]
        public string InvoiceNo { get; set; } = string.Empty;
        [Required]
        public string FullName { get; set; } = string.Empty;
        public string? Country { get; set; }
        public string? MobileNo { get; set; }
        public string? Email { get; set; }

        public int? UserId { get; set; }
        [Required]
        public int PilgrimCompanyId { get; set; }

        [Required]
        public int CompanyId { get; set; }
        [Required]
        public decimal TotalAmount { get; set; }
        [Required]
        public decimal TotalDiscount { get; set; }
        [Required]
        public decimal TotalNetAmount { get; set; }
        [Required]
        public decimal Paid { get; set; }
        [Required]
        public DateTime Date { get; set; }
        
        public OrderStatus Status { get; set; } = OrderStatus.OrderPlaced;

        public List<OrderDetailCreateModel>? OrderDetails { get; set; }
    }
}