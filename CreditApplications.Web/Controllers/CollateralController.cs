﻿using CreditApplications.ApplicationServices.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using CreditApplications.ApplicationServices.Domain.Models;
using CreditApplications.DataAccess.Entities;

namespace CreditApplications.Web.Controllers
{
    public class CollateralController : Controller
    {
        private readonly ILogger<CollateralController> _logger;
        private readonly ICollateralLogic _logic;

        public CollateralController(ILogger<CollateralController> logger, ICollateralLogic logic)
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
                _logger.LogError($"Failed to get collateral: {e}");
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
                _logger.LogError($"Failed to get collateral details: {e}");
                return RedirectToAction(nameof(Error));
            }
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CollateralModel model)
        {
            if (ModelState.IsValid)
            {
                await _logic.Create(model);
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

            var model = await _logic.GetById(id.Value);
            if (model == null)
            {
                _logger.LogInformation("No department found for {id}.", id.Value);
                return RedirectToAction(nameof(Error));
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CollateralModel model)
        {
            if (id != model.Id)
            {
                return RedirectToAction(nameof(Error));
            }

            if (ModelState.IsValid)
            {
                await _logic.Update(model);
                return RedirectToAction(nameof(List));
            }
            return View(model);
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
