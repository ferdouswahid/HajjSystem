using System;
using System.Collections.Generic;
using HajjSystem.Models.Enums;

namespace HajjSystem.Models.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public string InvoiceNo { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string? Country { get; set; }
        public string? MobileNo { get; set; }
        public string? Email { get; set; }
        public int? UserId { get; set; }
        public UserModel? User { get; set; }
        public int PilgrimCompanyId { get; set; }
        public CompanyModel? PilgrimCompany { get; set; }
        public int CompanyId { get; set; }
        public CompanyModel? Company { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal TotalNetAmount { get; set; }
        public decimal Paid { get; set; }
        public DateTime Date { get; set; }
        public OrderStatus Status { get; set; }
        public List<OrderDetailModel>? OrderDetails { get; set; }
        public List<OrderLogModel>? OrderLogs { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsEnabled { get; set; }
    }
}