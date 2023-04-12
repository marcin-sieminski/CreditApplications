﻿using Microsoft.AspNetCore.Mvc.Rendering;

namespace CreditApplications.Intranet.Helpers;

public static class Utilities
{
    public static string IsActive(this IHtmlHelper html, string controller, string action, int id)
    {
        var routeData = html.ViewContext.RouteData;
        var routeAction = (string)routeData.Values["action"];
        var routeController = (string)routeData.Values["controller"];
        string routeId = null;
        if (routeData.Values["id"] is not null)
        {
            routeId = routeData.Values["id"].ToString();
        }
        var returnActive = controller == routeController && ((action == routeAction) || string.IsNullOrEmpty(action) || ((routeAction == "Read"))) && id.ToString() == routeId;
        return returnActive ? "active bg-dark text-warning" : "";
    }

    public static string IsActiveTextSecondary(this IHtmlHelper html, string controller, string action)
    {
        var routeData = html.ViewContext.RouteData;
        var routeAction = (string)routeData.Values["action"];
        var routeControl = (string)routeData.Values["controller"];
        var returnActive = controller == routeControl && ((action == routeAction) || string.IsNullOrEmpty(action));
        return returnActive ? "text-warning" : "text-white";
    }
}