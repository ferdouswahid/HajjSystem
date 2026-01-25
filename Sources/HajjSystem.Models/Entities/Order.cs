using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HajjSystem.Models.Enums;

namespace HajjSystem.Models.Entities
{


    public class Order : BaseEntity
    {
        [Required]
        public string InvoiceNo { get; set; } = string.Empty;

        [Required]
        public string FullName { get; set; } = string.Empty;

        public string? Country { get; set; }
        public string? MobileNo { get; set; }
        public string? Email { get; set; }

        // Foreign key to User (pilgrim/customer)
        public int? UserId { get; set; }
        [ForeignKey("UserId")]
        public User? User { get; set; }

        // Foreign key to PilgrimCompany (outside KSA)
        public int PilgrimCompanyId { get; set; }
        [ForeignKey("PilgrimCompanyId")]
        public Company? PilgrimCompany { get; set; }

        // Foreign key to Company (local KSA)
        public int CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public Company? Company { get; set; }

        public decimal TotalAmount { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal TotalNetAmount { get; set; }
        public decimal Paid { get; set; }

        public DateTime Date { get; set; }

        public OrderStatus Status { get; set; }

        // Navigation property for OrderDetails (bi-directional)
        public ICollection<OrderDetail>? OrderDetails { get; set; }

        // Navigation property for OrderLogs (bi-directional)
        public ICollection<OrderLog>? OrderLogs { get; set; }
    }
}