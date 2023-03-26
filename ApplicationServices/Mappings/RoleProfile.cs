using AutoMapper;
using CreditApplications.ApplicationServices.Domain.Models;

namespace CreditApplications.ApplicationServices.Mappings;

public class RoleProfile : Profile
{
    public RoleProfile()
    {
        CreateMap<DataAccess.Entities.ProcessRole, Domain.Models.ProcessRoleModel>();
        CreateMap<Domain.Models.ProcessRoleModel, DataAccess.Entities.ProcessRole>();
    }
}