using CreditApplications.ApplicationServices.Domain.Models;

namespace CreditApplications.ApplicationServices.Domain.Interfaces;

public interface IDepartmentLogic
{
    Task<List<DepartmentModel>> GetAll();
    Task<DepartmentModel> GetById(int id);
    Task<DataAccess.Entities.Department> Create(DepartmentModel model);
    Task<int> Update(DepartmentModel model);
    Task<int> Delete(int id);
    Task<int> Inactivate(int id);
    Task<int> GetCount();
    bool EntityExists(int id);
}