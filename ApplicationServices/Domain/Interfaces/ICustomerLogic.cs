using CreditApplications.ApplicationServices.Domain.Models;

namespace CreditApplications.ApplicationServices.Domain.Interfaces;

public interface ICustomerLogic
{
    Task<List<Customer>> GetAll();
    Task<Customer> GetById(int id);
    Task<int> Insert(Customer entity);
    Task<int> Update(Customer entity);
    Task<int> Delete(int id);
    Task<int> GetCount();
}