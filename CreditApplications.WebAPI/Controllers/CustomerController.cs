using CreditApplications.ApplicationServices.Domain.Interfaces;
using CreditApplications.ApplicationServices.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CreditApplications.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly ICustomerLogic _customerLogic;

    public CustomerController(ICustomerLogic customerLogic)
    {
        _customerLogic = customerLogic;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CustomerModel>>> Get()
    {
        return await _customerLogic.GetAll();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CustomerModel>> Get(int id)
    {
        var model = await _customerLogic.GetById(id);
        if (model is null)
        {
            return NotFound();
        }

        return model;
    }

    [HttpPost]
    public async Task<ActionResult<CustomerModel>> Post(CustomerModel model)
    {
        var modelCreated = await _customerLogic.Create(model);
        return Ok(modelCreated);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<CustomerModel>> Put(int id, CustomerModel model)
    {
        if (id != model.Id)
        {
            return BadRequest();
        }

        try
        {
            await _customerLogic.Update(model);
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_customerLogic.EntityExists(id))
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
        var response = await _customerLogic.Delete(id);
        if (response == 0)
        {
            return NotFound();
        }

        return NoContent();
    }
}