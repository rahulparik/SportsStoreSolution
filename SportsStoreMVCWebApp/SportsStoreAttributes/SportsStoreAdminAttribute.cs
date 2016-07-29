using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace SportsStoreMVCWebApp.SportsStoreAttributes
{
    public class SportsStoreAdminAttribute : FilterAttribute, IAuthenticationFilter
    {
        string _rAdmin = "admin";

        public void OnAuthentication(AuthenticationContext filterContext)
        {
            if (!(filterContext.HttpContext.User.Identity.IsAuthenticated && filterContext.HttpContext.User.IsInRole(_rAdmin)))
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            if (filterContext.Result == null || filterContext.Result is HttpUnauthorizedResult)
            {
                filterContext.Result = new RedirectToRouteResult("Default", new System.Web.Routing.RouteValueDictionary { { "controller", "Account" }, { "action", "Login" }, { "returnurl", filterContext.HttpContext.Request.RawUrl } });
            }
        }
    }
}