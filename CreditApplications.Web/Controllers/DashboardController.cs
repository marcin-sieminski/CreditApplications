using AutoMapper;
using CreditApplications.ApplicationServices.Domain.Interfaces;
using CreditApplications.ApplicationServices.Domain.Logic;
using CreditApplications.ApplicationServices.Domain.Models;
using CreditApplications.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace CreditApplications.Web.Controllers
{
    public class DashboardController : Controller
    {
        private readonly CreditApplicationsDbContext _context;
        private readonly IMapper _mapper;

        public DashboardController(CreditApplicationsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<IActionResult> Index()
        {
            var cart = new CartLogic(_context, HttpContext, _mapper);
            var dashbordCartItems = await cart.GetCartItems();
            return View(dashbordCartItems);
        }

        public async Task<IActionResult> AddToCart(int id)
        {
            var cart = new CartLogic(_context, HttpContext, _mapper);
            await cart.AddToCart(id);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteFromCart(int id)
        {
            var cart = new CartLogic(_context, HttpContext, _mapper);
            cart.DeleteFromCart(id);
            return RedirectToAction("Index");
        }
    }
}
