using AutoMapper;
using CreditApplications.ApplicationServices.Domain.Models;

namespace CreditApplications.ApplicationServices.Mappings;

public class EmployeeProfile : Profile
{
    public EmployeeProfile()
    {
        CreateMap<DataAccess.Entities.Employee, Domain.Models.EmployeeModel>();
        CreateMap<Domain.Models.EmployeeModel, DataAccess.Entities.Employee>();
    }
}