using System;
using System.ComponentModel.DataAnnotations.Schema;
using HajjSystem.Models.Enums;

namespace HajjSystem.Models.Entities
{
    public class AirlineContractDetail : BaseEntity
    {
        // Foreign key to AirlineContract
        public int AirlineContractId { get; set; }
        [ForeignKey("AirlineContractId")]
        public AirlineContract? AirlineContract { get; set; }

        // Foreign key to RouteFrom (AirlineRoute)
        public int RouteFromId { get; set; }
        [ForeignKey("RouteFromId")]
        public AirlineRoute? RouteFrom { get; set; }

        // Foreign key to RouteTo (AirlineRoute)
        public int RouteToId { get; set; }
        [ForeignKey("RouteToId")]
        public AirlineRoute? RouteTo { get; set; }

        // Flight numbers
        public string? FlightNoDeparture { get; set; }
        public string? FlightNoArriaval { get; set; }

        // Price
        public decimal Price { get; set; }

        // Number of seats
        public int NoOfSeat { get; set; }

        // Reserved seats
        public int? ReservedSeat { get; set; }

        // Trip type (single, round)
        public TripType TripType { get; set; }

        // Departure date
        public DateTime DepartureDate { get; set; }

        // Arrival date (nullable)
        public DateTime? ArrivalDate { get; set; }

        // Foreign key to Company
        public int CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public Company? Company { get; set; }
        
        public ICollection<PackageAirline>? PackageAirlines { get; set; }
    }
}