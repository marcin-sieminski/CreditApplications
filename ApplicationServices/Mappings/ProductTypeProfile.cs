using AutoMapper;
using CreditApplications.ApplicationServices.Domain.Models;

namespace CreditApplications.ApplicationServices.Mappings;

public class ProductTypeProfile : Profile
{
    public ProductTypeProfile()
    {
        CreateMap<DataAccess.Entities.ProductType, Domain.Models.ProductTypeModel>();
        CreateMap<Domain.Models.ProductTypeModel, DataAccess.Entities.ProductType>();
    }
}