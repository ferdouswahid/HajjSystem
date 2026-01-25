using System;
using System.ComponentModel.DataAnnotations.Schema;
using HajjSystem.Models.Enums;

namespace HajjSystem.Models.Entities
{
    public class OrderLog : BaseEntity
    {
        // Foreign key to Order
        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public Order? Order { get; set; }

        // Status
        public OrderStatus Status { get; set; }

        // Date
        public DateTime Date { get; set; }
    }
}