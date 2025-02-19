using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace FribergCarRentalsHemuppgift.Areas.Admin.Filters
{
    public class AdminLoginAuthorizationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var isAdmin = context.HttpContext.Session.GetString("isAdmin");
            if (string.IsNullOrEmpty(isAdmin) && isAdmin != "true")
            {
                context.Result = new RedirectResult("~/Admin/Login");
            }
        }
    }
}
