using AutoMapper;
using HajjSystem.Models.Entities;
using HajjSystem.Models.Models;

namespace HajjSystem.Webapi.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Season, SeasonModel>();
        CreateMap<SeasonCreateModel, Season>();
        CreateMap<SeasonUpdateModel, Season>();
        
        CreateMap<Company, CompanyModel>();
        CreateMap<CompanyCreateModel, Company>();
        CreateMap<CompanyUpdateModel, Company>();
        
        CreateMap<AirlineRoute, AirlineRouteModel>();
        CreateMap<AirlineRouteCreateModel, AirlineRoute>();
        CreateMap<AirlineRouteUpdateModel, AirlineRoute>();
        
        CreateMap<Location, LocationModel>();
        CreateMap<LocationCreateModel, Location>();
        CreateMap<LocationUpdateModel, Location>();
        
        CreateMap<MealType, MealTypeModel>();
        CreateMap<MealTypeCreateModel, MealType>();
        CreateMap<MealTypeUpdateModel, MealType>();
        
        CreateMap<Vendor, VendorModel>();
        CreateMap<VendorCreateModel, Vendor>();
        CreateMap<VendorUpdateModel, Vendor>();
        
        CreateMap<VehicleRoute, VehicleRouteModel>();
        CreateMap<VehicleRouteCreateModel, VehicleRoute>();
        CreateMap<VehicleRouteUpdateModel, VehicleRoute>();
        
        CreateMap<VehicleDetail, VehicleDetailModel>();
        CreateMap<VehicleDetailCreateModel, VehicleDetail>();
        CreateMap<VehicleDetailUpdateModel, VehicleDetail>();
        
        CreateMap<Vehicle, VehicleModel>();
        CreateMap<VehicleCreateModel, Vehicle>();
        CreateMap<VehicleUpdateModel, Vehicle>();
        
        CreateMap<VehicleContract, VehicleContractModel>();
        CreateMap<VehicleContractCreateModel, VehicleContract>();
        CreateMap<VehicleContractUpdateModel, VehicleContract>();
    }
}
