using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CreditApplications.Mobile.Models;
using CreditApplications.ServiceReference;

namespace CreditApplications.Mobile.Services;

public class ApplicationStatusDataStore : DataStoreBase, IDataStore<ApplicationStatusForView>
{
    public List<ApplicationStatusForView> Items { get; set; }

    public ApplicationStatusDataStore()
    {
        var itemsFromService = _creditApplicationsService.ApplicationStatusAllAsync().Result;
        Items = new List<ApplicationStatusForView>();
        Items = itemsFromService.Select(model => new ApplicationStatusForView(model)).ToList();
    }

    public async Task<bool> AddItemAsync(ApplicationStatusForView item)
    {
        var itemToAdd = new ApplicationStatusModel()
        {
            ApplicationStatusName = item.ApplicationStatusName
        };

        var itemFromService = new ApplicationStatusForView(_creditApplicationsService.ApplicationStatusAsync(itemToAdd).Result);
        Items.Add(itemFromService);

        return await Task.FromResult(true);
    }

    public async Task<bool> UpdateItemAsync(ApplicationStatusForView item)
    {
        var oldItem = Items.FirstOrDefault(arg => arg.Id == item.Id);
        Items.Remove(oldItem);
        Items.Add(item);

        var model = new ApplicationStatusModel()
        {
            Id = item.Id,
            ApplicationStatusName = item.ApplicationStatusName
        };
        
        var result = _creditApplicationsService.ApplicationStatus3Async(model.Id, model);
        
        return await Task.FromResult(true);
    }

    public async Task<bool> DeleteItemAsync(int id)
    {
        var oldItem = Items.FirstOrDefault(arg => arg.Id == id);
        Items.Remove(oldItem);

        var result = _creditApplicationsService.ApplicationStatus4Async(id);
        
        return await Task.FromResult(true);
    }

    public async Task<ApplicationStatusForView> GetItemAsync(int id)
    {
        return await Task.FromResult(Items.FirstOrDefault(s => s.Id == id));
    }

    public async Task<IEnumerable<ApplicationStatusForView>> GetItemsAsync(bool forceRefresh = false)
    {
        return await Task.FromResult(Items);
    }
}