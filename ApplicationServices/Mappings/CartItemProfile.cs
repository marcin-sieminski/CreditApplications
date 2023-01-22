using System.Runtime.CompilerServices;
using AutoMapper;

namespace CreditApplications.ApplicationServices.Mappings;

public class CartItemProfile : Profile
{
    public CartItemProfile()
    {
        CreateMap<DataAccess.Entities.CartItem, Domain.Models.CartItem>()
            .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
            .ForMember(x => x.SessionId, y => y.MapFrom(z => z.SessionId))
            .ForMember(x => x.CreditApplicationId, y => y.MapFrom(z => z.CreditApplicationId))
            .ForMember(x => x.EmployeeId, y => y.MapFrom(z => z.EmployeeId))
            .ForMember(x => x.Created, y => y.MapFrom(z => z.Created))
            .ForMember(x => x.CreditApplication, y => y.Ignore())
            .ForMember(x => x.Employee, y => y.Ignore())
            .ForMember(x => x.CreditApplication, y => y.MapFrom(z => z.CreditApplication))
            .IncludeAllDerived()
            ;

        CreateMap<Domain.Models.CartItem, DataAccess.Entities.CartItem>();
    }
}