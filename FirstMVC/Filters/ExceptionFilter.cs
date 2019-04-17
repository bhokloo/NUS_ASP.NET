using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;

namespace FirstMVC.Filters
{
    public class ExceptionFilters :AuthenticationFilters, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            Debug.WriteLine(filterContext.GetType().Name);
            Debug.WriteLine("EXCEPTION EXCEUTED");
            filterContext.ExceptionHandled = true;
            filterContext.Result = new ViewResult
            {
                ViewName = "../Student/Department"
            };
            
        }
    }
}