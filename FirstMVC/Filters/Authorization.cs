using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstMVC.Filters
{
    public class Authorization : ActionFilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            string sessionid = HttpContext.Current.Request["sessionId"];

            Debug.WriteLine("ssVVVvdv" + sessionid);
        }
    }
}