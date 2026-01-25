using System;
using HajjSystem.Models.Enums;

namespace HajjSystem.Models.Models
{
    public class AirlineContractDetailModel
    {
        public int Id { get; set; }
        public int AirlineContractId { get; set; }
        public AirlineContractModel? AirlineContract { get; set; } 
        public int RouteFromId { get; set; }
         public AirlineRouteModel? RouteFrom { get; set; }

        public int RouteToId { get; set; }
        public AirlineRouteModel? RouteTo { get; set; }
        public string? FlightNoDeparture { get; set; }
        public string? FlightNoArriaval { get; set; }
        public decimal Price { get; set; }
        public int NoOfSeat { get; set; }
        public int? ReservedSeat { get; set; }
        public TripType TripType { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime? ArrivalDate { get; set; }
        public int CompanyId { get; set; }
        public CompanyModel? Company { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsEnabled { get; set; }
    }
}