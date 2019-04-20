using FirstMVC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Services;

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
        public JsonResult jsonWithModel(JsonBind data)
        {
           
            Debug.WriteLine(","+ data.name);

            return Json(data);

        }
    }
}