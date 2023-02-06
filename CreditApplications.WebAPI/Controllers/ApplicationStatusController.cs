using CreditApplications.ApplicationServices.Domain.Interfaces;
using CreditApplications.ApplicationServices.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CreditApplications.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ApplicationStatusController : ControllerBase
{
    private readonly IApplicationStatusLogic _logic;

    public ApplicationStatusController(IApplicationStatusLogic logic)
    {
        _logic = logic;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ApplicationStatusModel>>> Get()
    {
        return await _logic.GetAll();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApplicationStatusModel>> Get(int id)
    {
        var model = await _logic.GetById(id);
        if (model is null)
        {
            return NotFound();
        }

        return model;
    }

    [HttpPost]
    public async Task<ActionResult<ApplicationStatusModel>> Post(ApplicationStatusModel model)
    {
        var modelCreated = await _logic.Create(model);
        return Ok(modelCreated);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApplicationStatusModel>> Put(int id, ApplicationStatusModel model)
    {
        if (id != model.Id)
        {
            return BadRequest();
        }

        try
        {
            await _logic.Update(model);
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_logic.EntityExists(id))
            {
                return NotFound();
            }

            throw;
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var response = await _logic.Delete(id);
        if (response == 0)
        {
            return NotFound();
        }

        return NoContent();
    }
}