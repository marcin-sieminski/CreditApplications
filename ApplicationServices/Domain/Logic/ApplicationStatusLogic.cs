using AutoMapper;
using CreditApplications.ApplicationServices.Domain.Interfaces;
using CreditApplications.ApplicationServices.Domain.Models;
using CreditApplications.DataAccess.Repositories;

namespace CreditApplications.ApplicationServices.Domain.Logic;

public class ApplicationStatusLogic : IApplicationStatusLogic
{
    private readonly IRepository<DataAccess.Entities.ApplicationStatus> _repository;
    private readonly IMapper _mapper;

    public ApplicationStatusLogic(IRepository<DataAccess.Entities.ApplicationStatus> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<ApplicationStatusModel>> GetAll()
    {
        var dbEntities = await _repository.GetAll();
        var model = _mapper.Map<List<ApplicationStatusModel>>(dbEntities);
        return model;
    }

    public async Task<ApplicationStatusModel> GetById(int id)
    {
        var dbEntity = await _repository.GetById(id);
        var model = _mapper.Map<ApplicationStatusModel>(dbEntity);
        return model;
    }

    public async Task<ApplicationStatusModel> Create(ApplicationStatusModel model)
    {
        var dbEntity = _mapper.Map<DataAccess.Entities.ApplicationStatus>(model);
        dbEntity.Created = DateTime.Now;
        dbEntity.Modified = DateTime.Now;
        dbEntity.IsActive = true;
        var entityCreated = await _repository.Create(dbEntity);
        var modelCreated = _mapper.Map<ApplicationStatusModel>(entityCreated);
        return modelCreated;
    }

    public async Task<int> Update(ApplicationStatusModel model)
    {
        var entityForDb = _mapper.Map<DataAccess.Entities.ApplicationStatus>(model);
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
