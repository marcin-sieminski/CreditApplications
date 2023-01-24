using CreditApplications.ApplicationServices.Domain.Models;

namespace CreditApplications.ApplicationServices.Domain.Interfaces;

public interface ICreditApplicationLogic
{
    Task<List<CreditApplicationModel>> GetAll();
    Task<CreditApplicationModel> GetById(int id);
    Task<int> Create(CreditApplicationModel entity);
    Task<int> Update(CreditApplicationModel entity);
    Task<int> Delete(int id);
    Task<int> GetCount();
    Task<CreditApplicationModel> Initialize(CreditApplicationModel entity);
    bool EntityExists(int id);
}