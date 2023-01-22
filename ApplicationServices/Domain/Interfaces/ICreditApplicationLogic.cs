using CreditApplications.ApplicationServices.Domain.Models;

namespace CreditApplications.ApplicationServices.Domain.Interfaces;

public interface ICreditApplicationLogic
{
    Task<List<CreditApplication>> GetAll();
    Task<CreditApplication> GetById(int id);
    Task<int> Create(CreditApplication entity);
    Task<int> Update(CreditApplication entity);
    Task<int> Delete(int id);
    Task<int> GetCount();
    Task<CreditApplication> Initialize(CreditApplication entity);
}