using CreditApplications.ApplicationServices.Domain.Models;
using CreditApplications.DataAccess.Entities;

namespace CreditApplications.ApplicationServices.Domain.Interfaces;

public interface IApplicationStatusLogic
{
    Task<List<ApplicationStatusModel>> GetAll();
    Task<ApplicationStatusModel> GetById(int id);
    Task<ApplicationStatusModel> Create(ApplicationStatusModel model);
    Task<int> Update(ApplicationStatusModel model);
    Task<int> Delete(int id);
    Task<int> Inactivate(int id);
    Task<int> GetCount();
    bool EntityExists(int id);
}