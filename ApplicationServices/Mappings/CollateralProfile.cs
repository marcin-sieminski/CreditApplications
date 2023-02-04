using AutoMapper;
using CreditApplications.ApplicationServices.Domain.Models;

namespace CreditApplications.ApplicationServices.Mappings;

public class CollateralProfile : Profile
{
    public CollateralProfile()
    {
        CreateMap<DataAccess.Entities.Collateral, Domain.Models.CollateralModel>();
        CreateMap<Domain.Models.CollateralModel, DataAccess.Entities.Collateral>();
    }
}