using AutoMapper;

namespace CreditApplications.ApplicationServices.Mappings;

public class CreditApplicationProfile : Profile
{
    public CreditApplicationProfile()
    {
        CreateMap<DataAccess.Entities.CreditApplication, Domain.Models.CreditApplicationModel>()
            .ForMember(x => x.CustomerFirstName, y => y.MapFrom(z => z.Customer.CustomerFirstName))
            .ForMember(x => x.CustomerLastName, y => y.MapFrom(z => z.Customer.CustomerLastName))
            .ForMember(x => x.ProductTypeName, y => y.MapFrom(z => z.ProductType.ProductTypeName))
            .ForMember(x => x.ApplicationStatus, y => y.MapFrom(z => z.ApplicationStatus.ApplicationStatusName))
            .ForMember(x => x.ProductTypeId, y => y.MapFrom(z => z.ProductTypeId));
        
        CreateMap<Domain.Models.CreditApplicationModel, DataAccess.Entities.CreditApplication>()
            .ForMember(x => x.ProductTypeId, y => y.MapFrom(z => z.ProductTypeId));

    }
}
