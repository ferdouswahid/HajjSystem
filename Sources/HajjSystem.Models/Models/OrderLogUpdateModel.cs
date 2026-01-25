using System;
using System.ComponentModel.DataAnnotations;
using HajjSystem.Models.Enums;

namespace HajjSystem.Models.Models
{
    public class OrderLogUpdateModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int OrderId { get; set; }
        public OrderModel? Order { get; set; }
        [Required]
        public OrderStatus Status { get; set; }
        [Required]
        public DateTime Date { get; set; }
    }
}