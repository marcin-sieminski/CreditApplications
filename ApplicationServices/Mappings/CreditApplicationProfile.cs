using AutoMapper;

namespace CreditApplications.ApplicationServices.Mappings;

public class CreditApplicationProfile : Profile
{
    public CreditApplicationProfile()
    {
        CreateMap<DataAccess.Entities.CreditApplication, Domain.Models.CreditApplication>()
            .ForMember(x => x.CustomerFirstName, y => y.MapFrom(z => z.Customer.CustomerFirstName))
            .ForMember(x => x.CustomerLastName, y => y.MapFrom(z => z.Customer.CustomerLastName))
            .ForMember(x => x.ProductTypeName, y => y.MapFrom(z => z.ProductType.ProductTypeName))
            .ForMember(x => x.ApplicationStatus, y => y.MapFrom(z => z.ApplicationStatus.ApplicationStatusName));

        CreateMap<Domain.Models.CreditApplication, DataAccess.Entities.CreditApplication>();

    }
}
