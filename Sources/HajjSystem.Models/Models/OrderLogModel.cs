using System;
using HajjSystem.Models.Enums;

namespace HajjSystem.Models.Models
{
    public class OrderLogModel
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public OrderModel? Order { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime Date { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsEnabled { get; set; }
    }
}