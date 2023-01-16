using CreditApplications.DataAccess.Entities;

namespace CreditApplications.DataAccess.Repositories;

public interface IRepository<T> where T : EntityBase
{
    Task<List<T>> GetAll();
    Task<CreditApplication?> GetById(int id);
    Task<int> Insert(T entity);
    Task<int> Update(T entity);
    Task<int> Delete(int id);
    Task<int> GetCount();
}
