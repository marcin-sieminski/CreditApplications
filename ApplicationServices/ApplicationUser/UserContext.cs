﻿using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace CreditApplications.ApplicationServices.ApplicationUser;

public class UserContext : IUserContext
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserContext(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public CurrentUser GetCurrentUser()
    {
        var user = _httpContextAccessor?.HttpContext?.User;
        if (user == null)
        {
            throw new InvalidOperationException("Context user is not present");
        }

        var id = user.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
        var email = user.Claims.First(c => c.Type == ClaimTypes.Email).Value;
        return new CurrentUser(id, email);
    }
}