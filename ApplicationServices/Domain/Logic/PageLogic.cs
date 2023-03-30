using AutoMapper;
using CreditApplications.ApplicationServices.ApplicationUser;
using CreditApplications.ApplicationServices.Domain.Interfaces;
using CreditApplications.ApplicationServices.Domain.Models;
using CreditApplications.DataAccess.Repositories;
using CreditApplications.DataAccess.Entities;
namespace CreditApplications.ApplicationServices.Domain.Logic;

public class PageLogic : IPageLogic
{
    private readonly IRepository<DataAccess.Entities.Page> _repository;
    private readonly IMapper _mapper;
    private readonly IUserContext _userContext;

    public PageLogic(IRepository<DataAccess.Entities.Page> repository, IMapper mapper, IUserContext userContext)
    {
        _repository = repository;
        _mapper = mapper;
        _userContext = userContext;
    }

    public async Task<List<PageModel>> GetAll()
    {
        var dbEntities = await _repository.GetAll();
        var model = _mapper.Map<List<PageModel>>(dbEntities);
        return model;
    }

    public async Task<List<PageModel>> GetAllSorted()
    {
        var dbEntities = await _repository.GetAll();
        var model = _mapper.Map<List<PageModel>>(dbEntities.OrderBy(x => x.Position));
        return model;
    }

    public async Task<PageModel> GetById(int id)
    {
        var dbEntity = await _repository.GetById(id);
        var model = _mapper.Map<PageModel>(dbEntity);
        return model;
    }

    public async Task<Page> Create(PageModel model)
    {
        var dbEntity = _mapper.Map<Page>(model);
        dbEntity.Created = DateTime.Now;
        dbEntity.Modified = DateTime.Now;
        dbEntity.CreatedById = _userContext.GetCurrentUser().Id;
        dbEntity.IsActive = true;
        var entityCreated = await _repository.Create(dbEntity);
        return entityCreated;
    }

    public async Task<int> Update(PageModel model)
    {
        var entityForDb = _mapper.Map<Page>(model);
        entityForDb.Modified = DateTime.Now;
        entityForDb.ModifiedById = _userContext.GetCurrentUser().Id;
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
            dbEntity.InactivatedById = _userContext.GetCurrentUser().Id;
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
