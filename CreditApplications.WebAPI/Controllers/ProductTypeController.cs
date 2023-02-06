using CreditApplications.ApplicationServices.Domain.Interfaces;
using CreditApplications.ApplicationServices.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CreditApplications.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductTypeController : ControllerBase
{
    private readonly IProductTypeLogic _logic;

    public ProductTypeController(IProductTypeLogic logic)
    {
        _logic = logic;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductTypeModel>>> Get()
    {
        return await _logic.GetAll();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductTypeModel>> Get(int id)
    {
        var model = await _logic.GetById(id);
        if (model is null)
        {
            return NotFound();
        }

        return model;
    }

    [HttpPost]
    public async Task<ActionResult<ProductTypeModel>> Post(ProductTypeModel model)
    {
        var modelCreated = await _logic.Create(model);
        return Ok(modelCreated);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ProductTypeModel>> Put(int id, ProductTypeModel model)
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