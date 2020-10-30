using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DacSan.Areas.Guest
{
    public class GuestAuthorization : AuthorizeAttribute
    {
        public string LoginPage { get; set; }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                filterContext.HttpContext.Response.Redirect(LoginPage);
            }
            base.OnAuthorization(filterContext);
        }
    }
}