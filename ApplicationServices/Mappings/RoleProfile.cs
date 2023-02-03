using AutoMapper;
using CreditApplications.ApplicationServices.Domain.Models;

namespace CreditApplications.ApplicationServices.Mappings;

public class RoleProfile : Profile
{
    public RoleProfile()
    {
        CreateMap<DataAccess.Entities.Role, Domain.Models.RoleModel>();
        CreateMap<Domain.Models.RoleModel, DataAccess.Entities.Role>();
    }
}