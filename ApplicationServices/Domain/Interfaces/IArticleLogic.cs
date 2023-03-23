using CreditApplications.ApplicationServices.Domain.Models;

namespace CreditApplications.ApplicationServices.Domain.Interfaces;

public interface IArticleLogic
{
    Task<List<ArticleModel>> GetAll();
    Task<List<ArticleModel>> GetAllSorted();
    Task<ArticleModel> GetById(int id);
    Task<DataAccess.Entities.Article> Create(ArticleModel model);
    Task<int> Update(ArticleModel model);
    Task<int> Delete(int id);
    Task<int> Inactivate(int id);
    Task<int> GetCount();
    bool EntityExists(int id);
}