using CreditApplications.ApplicationServices.Domain.Models;

namespace CreditApplications.ApplicationServices.Domain.Interfaces;

public interface ICollateralLogic
{
    Task<List<CollateralModel>> GetAll();
    Task<CollateralModel> GetById(int id);
    Task<DataAccess.Entities.Collateral> Create(CollateralModel model);
    Task<int> Update(CollateralModel model);
    Task<int> Delete(int id);
    Task<int> Inactivate(int id);
    Task<int> GetCount();
    bool EntityExists(int id);
}