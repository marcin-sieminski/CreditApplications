using CreditApplications.ApplicationServices.Domain.Models;

namespace CreditApplications.ApplicationServices.Domain.Interfaces;

public interface ICreditApplication
{
    Task<List<CreditApplication>> GetAll();
    Task<CreditApplication?> GetById(int id);
    Task Insert(CreditApplication entity);
    Task Update(CreditApplication entity);
    Task Delete(int id);
}