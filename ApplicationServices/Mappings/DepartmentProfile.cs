using AutoMapper;
using CreditApplications.ApplicationServices.Domain.Models;

namespace CreditApplications.ApplicationServices.Mappings;

public class DepartmentProfile : Profile
{
    public DepartmentProfile()
    {
        CreateMap<DataAccess.Entities.Department, Domain.Models.DepartmentModel>();
        CreateMap<Domain.Models.DepartmentModel, DataAccess.Entities.Department>();
    }
}