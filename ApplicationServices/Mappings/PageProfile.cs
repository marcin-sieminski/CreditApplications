using AutoMapper;
using CreditApplications.ApplicationServices.Domain.Models;

namespace CreditApplications.ApplicationServices.Mappings;

public class PAgeProfile : Profile
{
    public PAgeProfile()
    {
        CreateMap<DataAccess.Entities.Page, Domain.Models.PageModel>();
        CreateMap<Domain.Models.PageModel, DataAccess.Entities.Page>();
    }
}