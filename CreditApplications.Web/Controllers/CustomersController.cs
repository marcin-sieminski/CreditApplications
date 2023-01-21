using CreditApplications.ApplicationServices.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CreditApplications.Web.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ILogger<CreditApplicationsController> _logger;
        private readonly ICustomerLogic _customersLogic;

        public IActionResult List()
        {
            return View();
        }
    }
}
