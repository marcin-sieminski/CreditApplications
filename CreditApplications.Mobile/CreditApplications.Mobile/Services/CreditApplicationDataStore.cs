using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CreditApplications.Mobile.Models;
using CreditApplications.ServiceReference;

namespace CreditApplications.Mobile.Services;

public class CreditApplicationDataStore : DataStoreBase, IDataStore<CreditApplicationForView>
{
    public List<CreditApplicationForView> Items { get; set; }

    public CreditApplicationDataStore()
    {
        var itemsFromService = _creditApplicationsService.CreditApplicationAllAsync().Result;
        Items = new List<CreditApplicationForView>();
        Items = itemsFromService.Select(model => new CreditApplicationForView(model)).ToList();
    }

    public async Task<bool> AddItemAsync(CreditApplicationForView item)
    {
        var itemToAdd = new CreditApplicationModel()
        {
            CustomerId = item.CustomerId,
            CustomerFirstName = item.CustomerFirstName,
            CustomerLastName = item.CustomerLastName,
            ProductTypeId = item.ProductTypeId,
            ProductTypeName = item.ProductTypeName,
            Currency = item.Currency,
            AmountRequested = item.AmountRequested,
            AmountGranted = item.AmountGranted,
            ApplicationStatus = item.ApplicationStatus,
            DateOfSubmission = item.DateOfSubmission,
            DateOfLastStatusChange = item.DateOfLastStatusChange,
            Notes = item.Notes,
            ApplicationStatusId = item.ApplicationStatusId
        };

        var itemFromService = new CreditApplicationForView(_creditApplicationsService.CreditApplicationAsync(itemToAdd).Result);
        Items.Add(item);

        return await Task.FromResult(true);
    }

    public async Task<bool> UpdateItemAsync(CreditApplicationForView item)
    {
        var oldItem = Items.FirstOrDefault(arg => arg.Id == item.Id);
        Items.Remove(oldItem);
        Items.Add(item);

        var model = new CreditApplicationModel()
        {
            Id = item.Id,
            CustomerId = item.CustomerId,
            CustomerFirstName = item.CustomerFirstName,
            CustomerLastName = item.CustomerLastName,
            ProductTypeId = item.ProductTypeId,
            ProductTypeName = item.ProductTypeName,
            Currency = item.Currency,
            AmountRequested = item.AmountRequested,
            AmountGranted = item.AmountGranted,
            ApplicationStatus = item.ApplicationStatus,
            DateOfSubmission = item.DateOfSubmission,
            DateOfLastStatusChange = item.DateOfLastStatusChange,
            Notes = item.Notes,
            ApplicationStatusId = item.ApplicationStatusId,
        };
        
        var result = _creditApplicationsService.CreditApplication3Async(model.Id, model);
        
        return await Task.FromResult(true);
    }

    public async Task<bool> DeleteItemAsync(int id)
    {
        var oldItem = Items.FirstOrDefault(arg => arg.Id == id);
        Items.Remove(oldItem);

        var result = _creditApplicationsService.CreditApplication4Async(id);
        
        return await Task.FromResult(true);
    }

    public async Task<CreditApplicationForView> GetItemAsync(int id)
    {
        return await Task.FromResult(Items.FirstOrDefault(s => s.Id == id));
    }

    public async Task<IEnumerable<CreditApplicationForView>> GetItemsAsync(bool forceRefresh = false)
    {
        return await Task.FromResult(Items);
    }
}