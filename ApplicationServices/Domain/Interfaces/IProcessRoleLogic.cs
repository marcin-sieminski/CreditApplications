using CreditApplications.ApplicationServices.Domain.Models;

namespace CreditApplications.ApplicationServices.Domain.Interfaces;

public interface IProcessRoleLogic
{
    Task<List<ProcessRoleModel>> GetAll();
    Task<ProcessRoleModel> GetById(int id);
    Task<DataAccess.Entities.ProcessRole> Create(ProcessRoleModel model);
    Task<int> Update(ProcessRoleModel model);
    Task<int> Delete(int id);
    Task<int> Inactivate(int id);
    Task<int> GetCount();
    bool EntityExists(int id);
}