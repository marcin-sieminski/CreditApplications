using CreditApplications.ApplicationServices.Domain.Models;

namespace CreditApplications.ApplicationServices.Domain.Interfaces;

public interface IRoleLogic
{
    Task<List<RoleModel>> GetAll();
    Task<RoleModel> GetById(int id);
    Task<DataAccess.Entities.Role> Create(RoleModel model);
    Task<int> Update(RoleModel model);
    Task<int> Delete(int id);
    Task<int> Inactivate(int id);
    Task<int> GetCount();
    bool EntityExists(int id);
}