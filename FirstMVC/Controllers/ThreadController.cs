using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;
using System.Threading;

namespace FirstMVC.Controllers
{
    public class ThreadController : Controller
    {
        public ActionResult AsyncBar()
        {
            Debug.WriteLine(Thread.CurrentThread.ManagedThreadId);
            Debug.WriteLine("Came Here");
            return null;
        }

        public ActionResult AsyncBar1()
        {
            Debug.WriteLine(Thread.CurrentThread.ManagedThreadId);
            System.Web.HttpContext.Current.Application.Lock();

            System.Web.HttpContext.Current.Application["var1"] = (int)System.Web.HttpContext.Current.Application["var1"] + 1;
            System.Web.HttpContext.Current.Application.UnLock();
            Debug.WriteLine("Came Here");
            return null;
        }
    }
}