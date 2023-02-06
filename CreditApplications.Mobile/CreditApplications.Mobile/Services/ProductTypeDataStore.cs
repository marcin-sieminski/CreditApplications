using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CreditApplications.Mobile.Models;
using CreditApplications.ServiceReference;

namespace CreditApplications.Mobile.Services;

public class ProductTypeDataStore : DataStoreBase, IDataStore<ProductTypeForView>
{
    public List<ProductTypeForView> Items { get; set; }

    public ProductTypeDataStore()
    {
        var itemsFromService = _creditApplicationsService.ProductTypeAllAsync().Result;
        Items = new List<ProductTypeForView>();
        Items = itemsFromService.Select(model => new ProductTypeForView(model)).ToList();
    }

    public async Task<bool> AddItemAsync(ProductTypeForView item)
    {
        var itemToAdd = new ProductTypeModel()
        {
            ProductTypeName = item.ProductTypeName
        };

        var itemFromService = new ProductTypeForView(_creditApplicationsService.ProductTypeAsync(itemToAdd).Result);
        Items.Add(itemFromService);

        return await Task.FromResult(true);
    }

    public async Task<bool> UpdateItemAsync(ProductTypeForView item)
    {
        var oldItem = Items.FirstOrDefault(arg => arg.Id == item.Id);
        Items.Remove(oldItem);
        Items.Add(item);

        var model = new ProductTypeModel()
        {
            Id = item.Id,
            ProductTypeName = item.ProductTypeName
        };
        
        var result = _creditApplicationsService.ProductType3Async(model.Id, model);
        
        return await Task.FromResult(true);
    }

    public async Task<bool> DeleteItemAsync(int id)
    {
        var oldItem = Items.FirstOrDefault(arg => arg.Id == id);
        Items.Remove(oldItem);

        var result = _creditApplicationsService.ProductType4Async(id);
        
        return await Task.FromResult(true);
    }

    public async Task<ProductTypeForView> GetItemAsync(int id)
    {
        return await Task.FromResult(Items.FirstOrDefault(s => s.Id == id));
    }

    public async Task<IEnumerable<ProductTypeForView>> GetItemsAsync(bool forceRefresh = false)
    {
        return await Task.FromResult(Items);
    }
}