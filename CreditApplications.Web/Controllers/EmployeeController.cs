using CreditApplications.ApplicationServices.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using CreditApplications.ApplicationServices.Domain.Models;
using CreditApplications.Web.ViewModels;

namespace CreditApplications.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IEmploeeLogic _logic;

        public EmployeeController(ILogger<EmployeeController> logger, IEmploeeLogic logic)
        {
            _logger = logger;
            _logic = logic;
        }

        public async Task<IActionResult> List()
        {
            try
            {
                var model = await _logic.GetAll();
                return View(model);
            }
            catch (Exception e)
            {
                _logger.LogError($"Failed to get employees: {e}");
                return RedirectToAction(nameof(Error));
            }
        }

        [Route("{controller}/Details/{id:int}")]
        public async Task<IActionResult> Details([FromRoute] int id)
        {
            try
            {
                var model = await _logic.GetById(id);
                return View(model);
            }
            catch (Exception e)
            {
                _logger.LogError($"Failed to get employee details: {e}");
                return RedirectToAction(nameof(Error));
            }
        }

        public async Task<IActionResult> Create()
        {
            var model = await _logic.Initialize(new EmployeeModel());
            var viewModel = new EmployeeViewModel(model);
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmployeeViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                await _logic.Create(viewModel.EmployeeModel);
                return RedirectToAction(nameof(List));
            }
            return View(viewModel);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                _logger.LogInformation("Null ID passed to Edit route.");
                return RedirectToAction(nameof(Error));
            }

            var model = await _logic.Initialize(await _logic.GetById(id.Value));
            var viewModel = new EmployeeViewModel(model);

            if (viewModel.EmployeeModel == null)
            {
                _logger.LogInformation("No employee found for {id}.", id.Value);
                return RedirectToAction(nameof(Error));
            }

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EmployeeViewModel viewModel)
        {
            if (id != viewModel.EmployeeModel.Id)
            {
                return RedirectToAction(nameof(Error));
            }

            if (ModelState.IsValid)
            {
                await _logic.Update(viewModel.EmployeeModel);
                return RedirectToAction(nameof(List));
            }
            return View(viewModel);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                var model = await _logic.GetById(id.Value);
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
            await _logic.Inactivate(id);
            return RedirectToAction(nameof(List));
        }

        public IActionResult Error()
        {
            return View("NotFound");
        }
    }
}
