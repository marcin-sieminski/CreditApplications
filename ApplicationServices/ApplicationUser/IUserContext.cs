namespace CreditApplications.ApplicationServices.ApplicationUser;

public interface IUserContext
{
    CurrentUser GetCurrentUser();
}