using CreditApplications.DataAccess.Entities;

namespace CreditApplications.ApplicationServices.Helpers;

public static class EntityBaseHelpers
{
    public static void SetCreate(this EntityBase entity)
    {
        entity.Created = DateTime.Now;
        entity.Modified = DateTime.Now;
        entity.IsActive = true;
    }

    public static void SetModified(this EntityBase entity)
    {
        entity.Modified = DateTime.Now;
    }

    public static void SetInactivated(this EntityBase entity)
    {
        entity.Inactivated = DateTime.Now;
        entity.IsActive = false;
    }
}