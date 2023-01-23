using CreditApplications.ApplicationServices.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using CreditApplications.ApplicationServices.Domain.Models;

namespace CreditApplications.Web.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ILogger<CreditApplicationController> _logger;
        private readonly ICustomerLogic _customersLogic;

        public CustomerController(ILogger<CreditApplicationController> logger, ICustomerLogic customersLogic)
        {
            _logger = logger;
            _customersLogic = customersLogic;
        }

        public async Task<IActionResult> List()
        {
            try
            {
                var model = await _customersLogic.GetAll();
                return View(model);
            }
            catch (Exception e)
            {
                _logger.LogError($"Failed to get customers: {e}");
                return RedirectToAction(nameof(Error));
            }
        }

        [Route("{controller}/Details/{id:int}")]
        public async Task<IActionResult> Details([FromRoute] int id)
        {
            try
            {
                var model = await _customersLogic.GetById(id);
                return View(model);
            }
            catch (Exception e)
            {
                _logger.LogError($"Failed to get credit application details: {e}");
                return RedirectToAction(nameof(Error));
            }
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Customer model)
        {
            if (ModelState.IsValid)
            {
                await _customersLogic.Create(model);
                return RedirectToAction(nameof(List));
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                _logger.LogInformation("Null ID passed to Edit route.");
                return RedirectToAction(nameof(Error));
            }

            var model = await _customersLogic.GetById(id.Value);
            if (model == null)
            {
                _logger.LogInformation("No product found for {id}.", id.Value);
                return RedirectToAction(nameof(Error));
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Customer model)
        {
            if (id != model.Id)
            {
                return RedirectToAction(nameof(Error));
            }

            if (ModelState.IsValid)
            {
                await _customersLogic.Update(model);
                return RedirectToAction(nameof(List));
            }
            return View(model);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                var model = await _customersLogic.GetById(id.Value);
                if (model == null)
                {
                    return RedirectToAction(nameof(Error));
                }

                return View(model);
            }

            return RedirectToAction(nameof(Error));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _customersLogic.Inactivate(id);
            return RedirectToAction(nameof(List));
        }

        public IActionResult Error()
        {
            return View("NotFound");
        }
    }
}
