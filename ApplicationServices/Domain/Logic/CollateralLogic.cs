using AutoMapper;
using CreditApplications.ApplicationServices.Domain.Interfaces;
using CreditApplications.ApplicationServices.Domain.Models;
using CreditApplications.DataAccess.Repositories;

namespace CreditApplications.ApplicationServices.Domain.Logic;

public class CollateralLogic : ICollateralLogic
{
    private readonly IRepository<DataAccess.Entities.Collateral> _repository;
    private readonly IMapper _mapper;

    public CollateralLogic(IRepository<DataAccess.Entities.Collateral> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<CollateralModel>> GetAll()
    {
        var dbEntities = await _repository.GetAll();
        var model = _mapper.Map<List<CollateralModel>>(dbEntities);
        return model;
    }

    public async Task<CollateralModel> GetById(int id)
    {
        var dbEntity = await _repository.GetById(id);
        var model = _mapper.Map<CollateralModel>(dbEntity);
        return model;
    }

    public async Task<DataAccess.Entities.Collateral> Create(CollateralModel model)
    {
        var dbEntity = _mapper.Map<DataAccess.Entities.Collateral>(model);
        dbEntity.Created = DateTime.Now;
        dbEntity.Modified = DateTime.Now;
        dbEntity.IsActive = true;
        var entityCreated = await _repository.Create(dbEntity);
        return entityCreated;
    }

    public async Task<int> Update(CollateralModel model)
    {
        var entityForDb = _mapper.Map<DataAccess.Entities.Collateral>(model);
        entityForDb.Modified = DateTime.Now;
        entityForDb.IsActive = true;
        var idUpdated = await _repository.Update(entityForDb);
        return idUpdated;
    }

    public async Task<int> Inactivate(int id)
    {
        var dbEntity = await _repository.GetById(id);
        if (dbEntity is not null)
        {
            dbEntity.Inactivated = DateTime.Now;
            dbEntity.IsActive = false;
        }
        return await _repository.Update(dbEntity); 
    }

    public async Task<int> Delete(int id)
    {
        var idDeleted = await _repository.Delete(id);
        return idDeleted;
    }

    public async Task<int> GetCount()
    {
        return await _repository.GetCount();
    }

    public bool EntityExists(int id)
    {
        return _repository.TryEntityExists(id);
    }
}
