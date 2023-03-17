using AutoMapper;
using CreditApplications.ApplicationServices.Domain.Models;

namespace CreditApplications.ApplicationServices.Mappings;

public class ArticleProfile : Profile
{
    public ArticleProfile()
    {
        CreateMap<DataAccess.Entities.Article, Domain.Models.ArticleModel>();
        CreateMap<Domain.Models.ArticleModel, DataAccess.Entities.Article>();
    }
}