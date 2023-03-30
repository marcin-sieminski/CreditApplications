using AutoMapper;
using CreditApplications.ApplicationServices.ApplicationUser;
using CreditApplications.ApplicationServices.Domain.Interfaces;
using CreditApplications.ApplicationServices.Domain.Models;
using CreditApplications.DataAccess;
using CreditApplications.DataAccess.Entities;
using CreditApplications.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CreditApplications.ApplicationServices.Domain.Logic;

public class ArticleLogic : IArticleLogic
{
    private readonly IRepository<Article> _repository;
    private readonly IMapper _mapper;
    private readonly CreditApplicationsDbContext _context;
    private readonly IUserContext _userContext;

    public ArticleLogic(IRepository<Article> repository, IMapper mapper, CreditApplicationsDbContext context, IUserContext userContext)
    {
        _repository = repository;
        _mapper = mapper;
        _context = context;
        _userContext = userContext;
    }

    public async Task<List<ArticleModel>> GetAll()
    {
        var dbEntities = await _repository.GetAll();
        var model = _mapper.Map<List<ArticleModel>>(dbEntities);
        return model;
    }

    public async Task<List<ArticleModel>> GetByPageIdSorted(int? pageId)
    {
        var dbEntities = await _repository.GetAll();
        var articles = new List<Article>();
        if (pageId > 0)
        {
            articles.AddRange(dbEntities.Where(x => x.PageId == pageId));
        }
        else
        {
            articles.AddRange(dbEntities);
        }
        var model = _mapper.Map<List<ArticleModel>>(articles.OrderBy(x => x.Position));
        return model;
    }

    public async Task<ArticleModel> GetById(int id)
    {
        var dbEntity = await _repository.GetById(id);
        var model = _mapper.Map<ArticleModel>(dbEntity);
        return model;
    }

    public async Task<Article> Create(ArticleModel model)
    {
        var dbEntity = _mapper.Map<Article>(model);
        dbEntity.Created = DateTime.Now;
        dbEntity.Modified = DateTime.Now;
        dbEntity.CreatedById = _userContext.GetCurrentUser().Id;
        dbEntity.IsActive = true;
        var entityCreated = await _repository.Create(dbEntity);
        return entityCreated;
    }

    public async Task<int> Update(ArticleModel model)
    {
        var entityForDb = _mapper.Map<Article>(model);
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

    public async Task<IEnumerable<PageModel>> GetAvailablePages()
    {
        var dbEntitiesPages = await _context.Pages.Where(x => x.IsActive).ToListAsync();
        var pageModels = _mapper.Map<List<PageModel>>(dbEntitiesPages.OrderBy(x => x.Position));

        return pageModels;
    }
}
