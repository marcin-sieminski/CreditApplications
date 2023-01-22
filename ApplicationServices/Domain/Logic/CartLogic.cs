using AutoMapper;
using CreditApplications.ApplicationServices.Domain.Interfaces;
using CreditApplications.DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using CartItem = CreditApplications.ApplicationServices.Domain.Models.CartItem;
using CreditApplication = CreditApplications.ApplicationServices.Domain.Models.CreditApplication;

namespace CreditApplications.ApplicationServices.Domain.Logic;

public class CartLogic : ICartLogic
{
    private readonly CreditApplicationsDbContext _context;
    private readonly string CartSessionId;
    private readonly IMapper _mapper;

    public CartLogic(CreditApplicationsDbContext dbContext, HttpContext httpContext, IMapper mapper)
    {
        _context = dbContext;
        _mapper = mapper;
        CartSessionId = GetCartSessionId(httpContext);
    }

    public string GetCartSessionId(HttpContext httpContext)
    {
        if (httpContext.Session.GetString("CartSessionId") == null)
        {
            if (!string.IsNullOrWhiteSpace(httpContext.User.Identity?.Name))
            {
                httpContext.Session.SetString("CartSessionId", httpContext.User.Identity.Name);
            }
            else
            {
                Guid tempIdSession = Guid.NewGuid();
                httpContext.Session.SetString("CartSessionId", tempIdSession.ToString());
            }
        }
        return httpContext.Session.GetString("CartSessionId");
    }

    public async Task AddToCart(int id)
    {
        var cartItemToAdd = _context.CartItems.FirstOrDefault(x => x.SessionId == CartSessionId && x.CreditApplicationId == id);
        if (cartItemToAdd == null)
        {
            var newCartItem = new CartItem()
            {
                SessionId = CartSessionId,
                CreditApplicationId = id,
                EmployeeId = 1,
                Created = DateTime.Now
            };
            var newCartItemdbEntity = _mapper.Map<CreditApplications.DataAccess.Entities.CartItem>(newCartItem);
            _context.CartItems.Add(newCartItemdbEntity);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<List<CartItem>> GetCartItems()
    {
        var cartItemsModels = new List<CartItem>();
        var dbCartItems = await _context.CartItems.Where(x => x.SessionId == CartSessionId)
            .Include(x => x.CreditApplication)
            .Include(x => x.CreditApplication.Customer)
            .Include(x => x.Employee)
            .ToListAsync();
        if (dbCartItems.Count > 0)
        {
            cartItemsModels.AddRange(_mapper.Map<List<CartItem>>(dbCartItems));
        }
        return cartItemsModels;
    }

    public void DeleteFromCart(int id)
    {
        var cartItemToDelete = _context.CartItems.FirstOrDefault(x => x.Id == id);
        if (cartItemToDelete != null)
        {
            var result = _context.CartItems.Remove(cartItemToDelete);
            _context.SaveChanges();
        }
    }
}