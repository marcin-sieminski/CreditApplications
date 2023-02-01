using CreditApplications.ApplicationServices.Domain.Models;

namespace CreditApplications.ApplicationServices.Domain.Interfaces;

public interface IProductTypeLogic
{
    Task<List<ProductTypeModel>> GetAll();
    Task<ProductTypeModel> GetById(int id);
    Task<DataAccess.Entities.ProductType> Create(ProductTypeModel model);
    Task<int> Update(ProductTypeModel model);
    Task<int> Delete(int id);
    Task<int> Inactivate(int id);
    Task<int> GetCount();
    bool EntityExists(int id);
}