using CreditApplications.ApplicationServices.Domain.Interfaces;
using CreditApplications.ApplicationServices.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CreditApplications.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CreditApplicationController : ControllerBase
{
    private readonly ICreditApplicationLogic _creditApplicationLogic;

    public CreditApplicationController(ICreditApplicationLogic creditApplicationLogic)
    {
        _creditApplicationLogic = creditApplicationLogic;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CreditApplicationModel>>> Get()
    {
        return await _creditApplicationLogic.GetAll();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CreditApplicationModel>> Get(int id)
    {
        var model = await _creditApplicationLogic.GetById(id);
        if (model is null)
        {
            return NotFound();
        }

        return model;
    }

    [HttpPost]
    public async Task<ActionResult<CreditApplicationModel>> Post(CreditApplicationModel model)
    {
        var idCreated = await _creditApplicationLogic.Create(model);
        return CreatedAtAction("Get", new { id = idCreated, model });
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<CreditApplicationModel>> Put(int id, CreditApplicationModel model)
    {
        if (id != model.Id)
        {
            return BadRequest();
        }

        try
        {
            await _creditApplicationLogic.Update(model);
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_creditApplicationLogic.EntityExists(id))
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
        var response = await _creditApplicationLogic.Delete(id);
        if (response == 0)
        {
            return NotFound();
        }

        return NoContent();
    }
}