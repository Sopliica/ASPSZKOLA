using AutoMapper;
using WebApplication4.Models;
using WebApplication4.ViewModels;


namespace WebApplication4.Mapping;

public class OrganizationProfile : Profile
{
    public OrganizationProfile()
    {
        CreateMap<Vehicle, VehicleView>();
        CreateMap<Rental, RentalView>();
        CreateMap<Reservation, ReservationView>();
        CreateMap<VehicleType, VehicleTypeView>();
    }
}

