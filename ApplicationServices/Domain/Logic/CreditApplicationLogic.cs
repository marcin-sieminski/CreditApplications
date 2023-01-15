using CreditApplications.ApplicationServices.Domain.Interfaces;
using CreditApplications.ApplicationServices.Domain.Models;
using CreditApplications.DataAccess.Repositories;

namespace CreditApplications.ApplicationServices.Domain.Logic;

public class CreditApplicationLogic : ICreditApplication
{
    private readonly CreditApplicationsRepository _repository;

    public CreditApplicationLogic(CreditApplicationsRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<CreditApplication>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<CreditApplication> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task Insert(CreditApplication entity)
    {
        throw new NotImplementedException();
    }

    public Task Update(CreditApplication entity)
    {
        throw new NotImplementedException();
    }

    public Task Delete(int id)
    {
        throw new NotImplementedException();
    }
}