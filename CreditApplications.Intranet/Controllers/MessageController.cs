using CreditApplications.DataAccess;
using CreditApplications.DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CreditApplications.Intranet.Controllers;

public class MessageController : Controller
{
    private readonly CreditApplicationsDbContext _context;

    public MessageController(CreditApplicationsDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index(int? id)
    {
        ViewBag.MessageModel = _context.Messages.Where(x => x.IsActive).OrderByDescending(x => x.Created).ToList();
        var model = await _context.Messages.FirstOrDefaultAsync(x => x.IsActive && x.Id == id);
        if (model == null)
        {
            return NotFound();
        }
        return View(model);
    }

    public async Task<IActionResult> List()
    {
        var model = await _context.Messages.Where(x => x.IsActive).ToListAsync();
        return View(model);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Message model)
    {
        if (ModelState.IsValid)
        {
            model.IsActive = true;
            model.Created = DateTime.Now;
            _context.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(List));
        }
        return View(model);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return RedirectToAction(nameof(Error));
        }

        var model = await _context.Messages.SingleAsync(x => x.Id == id);
        if (model == null)
        {
            return RedirectToAction(nameof(Error));
        }

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Message model)
    {
        if (id != model.Id)
        {
            return RedirectToAction(nameof(Error));
        }

        if (ModelState.IsValid)
        {
            var dbEntity = _context.Messages.Single(x => x.Id == model.Id);
            dbEntity.Body = model.Body;
            dbEntity.Title = model.Title;
            dbEntity.Modified = DateTime.Now;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(List));
        }
        return View(model);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id != null)
        {
            var model = _context.Messages.Single(x => x.Id == id);
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
        var dbEntity = _context.Messages.Single(x => x.Id == id);
        dbEntity.IsActive = false;
        dbEntity.Inactivated = DateTime.Now;
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(List));
    }

    public IActionResult Error()
    {
        return View("NotFound");
    }
}