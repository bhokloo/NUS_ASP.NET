using FirstMVC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstMVC.Controllers
{
    public class XMLHttpRequestController : Controller
    {

        // BINDING JSON OBJECTS

        public ActionResult json()
        {
            return View();


        }

        [HttpPost]
        public JsonResult json(string s)
        {
            object ob1 = new { id = "aaaa", msg = "hello" };
            return Json(ob1, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public JsonResult jsonWithModel(String sessionId, JsonBind data)
        {
            //object ob1 = new { id = "aaaa", msg = "hello" };
            Debug.WriteLine("ffhhhh"+ sessionId +","+ data.name);
            return Json(data);

        }
    }
}