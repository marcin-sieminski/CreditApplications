﻿using CreditApplications.DataAccess.Entities;

namespace CreditApplications.DataAccess.Repositories;

public interface IRepository<T> where T : EntityBase
{
    Task<List<T>> GetAll();
    Task<T> GetById(int id);
    Task<T> Create(T entity);
    Task<int> Update(T entity);
    Task<int> Delete(int id);
    Task<int> GetCount();
    bool TryEntityExists(int id);
}
