using System;
using System.Diagnostics;
using CreditApplications.Mobile.Models;
using CreditApplications.Mobile.Views;
using Xamarin.Forms;

namespace CreditApplications.Mobile.ViewModels;

[QueryProperty(nameof(ItemId), nameof(ItemId))]
public class CustomerDetailViewModel : BaseViewModel<CustomerForView>
{
    private int itemId;
    private string customerFirstName;
    private string customerLastName;
    public int Id { get; set; }

    public string CustomerFirstName
    {
        get => customerFirstName;
        set => SetProperty(ref customerFirstName, value);
    }

    public string CustomerLastName
    {
        get => customerLastName;
        set => SetProperty(ref customerLastName, value);
    }

    public int ItemId
    {
        get
        {
            return itemId;
        }
        set
        {
            itemId = value;
            LoadItemId(value);
        }
    }

    public async void LoadItemId(int itemId)
    {
        try
        {
            var item = await DataStore.GetItemAsync(itemId);
            Id = item.Id;
            CustomerFirstName = item.CustomerFirstName;
            CustomerLastName = item.CustomerLastName;
        }
        catch (Exception)
        {
            Debug.WriteLine("Failed to Load Item");
        }
    }
}


