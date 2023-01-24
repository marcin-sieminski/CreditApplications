using AutoMapper;
using CreditApplications.ApplicationServices.Domain.Models;

namespace CreditApplications.ApplicationServices.Mappings;

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<DataAccess.Entities.Customer, Domain.Models.CustomerModel>();
        CreateMap<Domain.Models.CustomerModel, DataAccess.Entities.Customer>();
    }
}