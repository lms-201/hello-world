using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CourseManager.Models.ValidatableObjects;
using CourseManager.Models;

namespace CourseManager.Filters
{
    public class RequireAuthenticationAttribute : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Session != null)
            {
                var Suser = filterContext.HttpContext.Session["user"];
                var user = (Suser != null ? Suser.ToString() : " ");
                if (!string.IsNullOrWhiteSpace(user))
                {
                    return;
                }

                var cookie = filterContext.HttpContext.Request.Cookies["user"];
                var temp = (cookie != null ? cookie.ToString() : " ");
                if (string.IsNullOrWhiteSpace(temp))
                {
                    throw new UnauthorizedException();
                }
             
                var content = temp.DecryptQueryString();
                CourseManagerEntities db = new CourseManagerEntities();
                if (!db.Users.Any(u => u.Account == content))
                {
                    throw new UnauthorizedException();
                }

            }
        }
    }
}