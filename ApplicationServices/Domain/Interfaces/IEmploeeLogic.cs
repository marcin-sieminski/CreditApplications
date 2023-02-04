using CreditApplications.ApplicationServices.Domain.Models;

namespace CreditApplications.ApplicationServices.Domain.Interfaces;

public interface IEmploeeLogic
{
    Task<List<EmployeeModel>> GetAll();
    Task<EmployeeModel> GetById(int id);
    Task<DataAccess.Entities.Employee> Create(EmployeeModel model);
    Task<int> Update(EmployeeModel model);
    Task<int> Delete(int id);
    Task<int> Inactivate(int id);
    Task<int> GetCount();
    bool EntityExists(int id);
    Task<EmployeeModel> Initialize(EmployeeModel model);
}