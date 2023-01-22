using Microsoft.AspNetCore.Http;
using CartItem = CreditApplications.ApplicationServices.Domain.Models.CartItem;

namespace CreditApplications.ApplicationServices.Domain.Interfaces;

public interface ICartLogic
{
    string GetCartSessionId(HttpContext httpContext);
    Task AddToCart(int id);
    Task<List<CartItem>> GetCartItems();
    void DeleteFromCart(int id);
}