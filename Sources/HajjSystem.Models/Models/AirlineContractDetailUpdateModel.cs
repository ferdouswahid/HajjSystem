using System;
using System.ComponentModel.DataAnnotations;
using HajjSystem.Models.Enums;

namespace HajjSystem.Models.Models
{
    public class AirlineContractDetailUpdateModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int AirlineContractId { get; set; }
         public AirlineContractModel? AirlineContract { get; set; } 
        [Required]
        public int RouteFromId { get; set; }
         public AirlineRouteModel? RouteFrom { get; set; }
        [Required]
        public int RouteToId { get; set; }
         public AirlineRouteModel? RouteTo { get; set; }        
        public string? FlightNoDeparture { get; set; }
        public string? FlightNoArriaval { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int NoOfSeat { get; set; }
        public int? ReservedSeat { get; set; }
        [Required]
        public TripType TripType { get; set; }
        [Required]
        public DateTime DepartureDate { get; set; }
        public DateTime? ArrivalDate { get; set; }
        [Required]
        public int CompanyId { get; set; }
        public CompanyModel? Company { get; set; }

    }
}