using CreditApplications.ApplicationServices.Domain.Models;

namespace CreditApplications.ApplicationServices.Domain.Interfaces;

public interface IPageLogic
{
    Task<List<PageModel>> GetAll();
    Task<List<PageModel>> GetAllSorted();
    Task<PageModel> GetById(int id);
    Task<DataAccess.Entities.Page> Create(PageModel model);
    Task<int> Update(PageModel model);
    Task<int> Delete(int id);
    Task<int> Inactivate(int id);
    Task<int> GetCount();
    bool EntityExists(int id);
}