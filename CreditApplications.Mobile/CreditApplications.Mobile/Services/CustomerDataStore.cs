using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CreditApplications.Mobile.Models;
using CreditApplications.ServiceReference;

namespace CreditApplications.Mobile.Services;

public class CustomerDataStore : DataStoreBase, IDataStore<CustomerForView>
{
    public List<CustomerForView> Items { get; set; }

    public CustomerDataStore()
    {
        var itemsFromService = _creditApplicationsService.CustomerAllAsync().Result;
        Items = new List<CustomerForView>();
        Items = itemsFromService.Select(model => new CustomerForView(model)).ToList();
    }

    public async Task<bool> AddItemAsync(CustomerForView item)
    {
        var itemToAdd = new CustomerModel()
        {
            CustomerFirstName = item.CustomerFirstName,
            CustomerLastName = item.CustomerLastName,
            Country = item.Country,
            City = item.City,
            PostalCode = item.PostalCode,
            Street = item.Street,
            AddressNumber = item.AddressNumber,
            PhoneNumber = item.PhoneNumber,
            Email = item.Email
        };

        var itemFromService = new CustomerForView(_creditApplicationsService.CustomerAsync(itemToAdd).Result);
        Items.Add(itemFromService);

        return await Task.FromResult(true);
    }

    public async Task<bool> UpdateItemAsync(CustomerForView item)
    {
        var oldItem = Items.FirstOrDefault(arg => arg.Id == item.Id);
        Items.Remove(oldItem);
        Items.Add(item);

        var model = new CustomerModel()
        {
            Id = item.Id,
            CustomerFirstName = item.CustomerFirstName,
            CustomerLastName = item.CustomerLastName,
            Country = item.Country,
            City = item.City,
            PostalCode = item.PostalCode,
            Street = item.Street,
            AddressNumber = item.AddressNumber,
            PhoneNumber = item.PhoneNumber,
            Email = item.Email
        };
        
        var result = _creditApplicationsService.Customer3Async(model.Id, model);
        
        return await Task.FromResult(true);
    }

    public async Task<bool> DeleteItemAsync(int id)
    {
        var oldItem = Items.FirstOrDefault(arg => arg.Id == id);
        Items.Remove(oldItem);

        var result = _creditApplicationsService.Customer4Async(id);
        
        return await Task.FromResult(true);
    }

    public async Task<CustomerForView> GetItemAsync(int id)
    {
        return await Task.FromResult(Items.FirstOrDefault(s => s.Id == id));
    }

    public async Task<IEnumerable<CustomerForView>> GetItemsAsync(bool forceRefresh = false)
    {
        return await Task.FromResult(Items);
    }
}