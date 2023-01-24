using CreditApplications.ServiceReference;

namespace CreditApplications.Mobile.Services;

public class DataStoreBase
{
    protected readonly CreditApplicationsService _creditApplicationsService;

    public DataStoreBase()
    {
        _creditApplicationsService = new CreditApplicationsService("https://localhost:7109", new System.Net.Http.HttpClient());
    }
}