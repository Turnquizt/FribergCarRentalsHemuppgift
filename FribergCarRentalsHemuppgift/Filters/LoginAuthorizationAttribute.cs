using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration.UserSecrets;

namespace FribergCarRentalsHemuppgift.Filters
{
    public class LoginAuthorizationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var userId = context.HttpContext.Session.GetString("userId");
            if (string.IsNullOrEmpty(userId))
            {
                context.Result = new RedirectResult("~/Customer/LoginAndRegister");
            }
        }
    }
}
