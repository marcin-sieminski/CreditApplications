using AutoMapper;
using CreditApplications.ApplicationServices.Domain.Interfaces;
using CreditApplications.ApplicationServices.Domain.Models;
using CreditApplications.DataAccess.Repositories;

namespace CreditApplications.ApplicationServices.Domain.Logic;

public class CreditApplicationLogic : ICreditApplication
{
    private readonly CreditApplicationsRepository _repository;
    private readonly IMapper _mapper;

    public CreditApplicationLogic(CreditApplicationsRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<CreditApplication>> GetAll()
    {
        var creditApplicationsFromDb = await _repository.GetAll();
        var creditApplications = _mapper.Map<List<CreditApplication>>(creditApplicationsFromDb);
        return creditApplications;
    }

    public async Task<CreditApplication> GetById(int id)
    {
        var creditApplicationFromDb = await _repository.GetById(id);
        var creditApplication = _mapper.Map<CreditApplication>(creditApplicationFromDb);
        return creditApplication;
    }

    public async Task<int> Insert(CreditApplication entity)
    {
        var creditApplicationForDb = _mapper.Map<DataAccess.Entities.CreditApplication>(entity);
        var id = await _repository.Insert(creditApplicationForDb);
        return id;
    }

    public async Task<int> Update(CreditApplication entity)
    {
        var creditApplicationForDb = _mapper.Map<DataAccess.Entities.CreditApplication>(entity);
        var id = await _repository.Update(creditApplicationForDb);
        return id;
    }

    public async Task<int> Delete(int id)
    {
        var idDeleted = await _repository.Delete(id);
        return idDeleted;
    }

    public async Task<int> GetActiveApplicationsNumber()
    {
        return await GetActiveApplicationsNumber();
    }
}
