using AutoMapper;
using CreditApplications.ApplicationServices.Domain.Interfaces;
using CreditApplications.ApplicationServices.Domain.Models;
using CreditApplications.DataAccess;
using CreditApplications.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CreditApplications.ApplicationServices.Domain.Logic;

public class ArticleLogic : IArticleLogic
{
    private readonly IRepository<DataAccess.Entities.Article> _repository;
    private readonly IMapper _mapper;
    private readonly CreditApplicationsDbContext _context;

    public ArticleLogic(IRepository<DataAccess.Entities.Article> repository, IMapper mapper, CreditApplicationsDbContext context)
    {
        _repository = repository;
        _mapper = mapper;
        _context = context;
    }

    public async Task<List<ArticleModel>> GetAll()
    {
        var dbEntities = await _repository.GetAll();
        var model = _mapper.Map<List<ArticleModel>>(dbEntities);
        return model;
    }

    public async Task<List<ArticleModel>> GetAllSorted()
    {
        var dbEntities = await _repository.GetAll();
        var model = _mapper.Map<List<ArticleModel>>(dbEntities.OrderBy(x => x.Position));
        return model;
    }

    public async Task<ArticleModel> GetById(int id)
    {
        var dbEntity = await _repository.GetById(id);
        var model = _mapper.Map<ArticleModel>(dbEntity);
        return model;
    }

    public async Task<DataAccess.Entities.Article> Create(ArticleModel model)
    {
        var dbEntity = _mapper.Map<DataAccess.Entities.Article>(model);
        dbEntity.Created = DateTime.Now;
        dbEntity.Modified = DateTime.Now;
        dbEntity.IsActive = true;
        var entityCreated = await _repository.Create(dbEntity);
        return entityCreated;
    }

    public async Task<int> Update(ArticleModel model)
    {
        var entityForDb = _mapper.Map<DataAccess.Entities.Article>(model);
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

    public async Task<IEnumerable<PageModel>> GetAvailablePages()
    {
        var dbEntitiesPages = await _context.Pages.Where(x => x.IsActive).ToListAsync();
        var pageModels = _mapper.Map<List<PageModel>>(dbEntitiesPages.OrderBy(x => x.Position));

        return pageModels;
    }
}
