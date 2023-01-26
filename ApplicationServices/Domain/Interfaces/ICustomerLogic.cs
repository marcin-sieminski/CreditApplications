using CreditApplications.ApplicationServices.Domain.Models;

namespace CreditApplications.ApplicationServices.Domain.Interfaces;

public interface ICustomerLogic
{
    Task<List<CustomerModel>> GetAll();
    Task<CustomerModel> GetById(int id);
    Task<DataAccess.Entities.Customer> Create(CustomerModel entity);
    Task<int> Update(CustomerModel entity);
    Task<int> Delete(int id);
    Task<int> Inactivate(int id);
    Task<int> GetCount();
    bool EntityExists(int id);

}