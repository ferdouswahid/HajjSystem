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
        
        CreateMap<User, UserModel>();
        //CreateMap<UserCreateModel, User>();
        //CreateMap<UserUpdateModel, User>();
        
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
        CreateMap<VehicleCreateModel, Vehicle>()
            .ForMember(dest => dest.VehicleDetails, opt => opt.Ignore())
            .ForMember(dest => dest.VehicleContracts, opt => opt.Ignore());
        CreateMap<VehicleUpdateModel, Vehicle>()
            .ForMember(dest => dest.VehicleDetails, opt => opt.Ignore())
            .ForMember(dest => dest.VehicleContracts, opt => opt.Ignore());
        
        CreateMap<VehicleContract, VehicleContractModel>();
        CreateMap<VehicleContractCreateModel, VehicleContract>();
        CreateMap<VehicleContractUpdateModel, VehicleContract>();

        // --- Added missing mappings ---
        CreateMap<AirlineContract, AirlineContractModel>();
        CreateMap<AirlineContractCreateModel, AirlineContract>();
        CreateMap<AirlineContractUpdateModel, AirlineContract>();

        CreateMap<AirlineContractDetail, AirlineContractDetailModel>();
        CreateMap<AirlineContractDetailCreateModel, AirlineContractDetail>();
        CreateMap<AirlineContractDetailUpdateModel, AirlineContractDetail>();

        CreateMap<Package, PackageModel>();
        CreateMap<PackageCreateModel, Package>();
        CreateMap<PackageUpdateModel, Package>();

        CreateMap<PackageType, PackageTypeModel>();
        CreateMap<PackageTypeCreateModel, PackageType>();
        CreateMap<PackageTypeUpdateModel, PackageType>();

        CreateMap<PackageVehicle, PackageVehicleModel>();
        CreateMap<PackageVehicleCreateModel, PackageVehicle>();
        CreateMap<PackageVehicleUpdateModel, PackageVehicle>();

        CreateMap<PackageAirline, PackageAirlineModel>();
        CreateMap<PackageAirlineCreateModel, PackageAirline>();
        CreateMap<PackageAirlineUpdateModel, PackageAirline>();

        CreateMap<MealServiceLevel, MealServiceLevelModel>();
        CreateMap<MealServiceLevelCreateModel, MealServiceLevel>();
        CreateMap<MealServiceLevelUpdateModel, MealServiceLevel>();

        CreateMap<Contract, ContractModel>();
        CreateMap<ContractCreateModel, Contract>();
        CreateMap<ContractUpdateModel, Contract>();

        CreateMap<Order, OrderModel>();
        CreateMap<OrderCreateModel, Order>();
        CreateMap<OrderUpdateModel, Order>();

        CreateMap<OrderDetail, OrderDetailModel>();
        CreateMap<OrderDetailCreateModel, OrderDetail>();
        CreateMap<OrderDetailUpdateModel, OrderDetail>();

        CreateMap<OrderLog, OrderLogModel>();
        CreateMap<OrderLogCreateModel, OrderLog>();
        CreateMap<OrderLogUpdateModel, OrderLog>();
    }
}
