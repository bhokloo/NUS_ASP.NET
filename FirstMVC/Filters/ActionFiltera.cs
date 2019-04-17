using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;

namespace FirstMVC.Filters
{
    public class ActionFiltera : ActionFilterAttribute, IActionFilter
    {
        //Gets first executed
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Debug.WriteLine("OnActionExecuting");

        }

        //Gets executed after the method..but before VIEW...
        //EVEN AUTHENTICATION AND AUTHORIZATION FOLLOWS THE SAME
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            Debug.WriteLine("OnActionExecuted");
        }

       
    }
}