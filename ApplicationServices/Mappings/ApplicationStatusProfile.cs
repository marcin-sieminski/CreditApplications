using AutoMapper;

namespace CreditApplications.ApplicationServices.Mappings;

public class ApplicationStatusProfile : Profile
{
    public ApplicationStatusProfile()
    {
        CreateMap<DataAccess.Entities.ApplicationStatus, Domain.Models.ApplicationStatusModel>();
        CreateMap<Domain.Models.ApplicationStatusModel, DataAccess.Entities.ApplicationStatus>();
    }
}