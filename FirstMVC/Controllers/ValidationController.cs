using FirstMVC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstMVC.Controllers
{
    public class ValidationController : Controller
    {
        //______________________CLIENT SIDE VALIDATION ___________________________________________________________________

        [HttpPost]
        public ActionResult ClientSideValidation()
        {
            if (ModelState.IsValid)
            {
                ClientValidation emp = new ClientValidation();
                UpdateModel(emp);
                ViewBag.emp1 = emp;
                return View(emp);
            }

            return View();
        }


        //Vlidating one field with JSON true or False
        [HttpPost]
        public ActionResult validationOfOneFiled(string username)
        {
            if (username.Any(char.IsDigit))
            {
                return Json(false);
            }
            return Json(true);
        }





        //______________________SERVER SIDE VALIDATION ___________________________________________________________________


        public ActionResult ServerSideValidation31(string s)
        {
            Debug.WriteLine("HttpGet Server");
            return View("../Filter/ServerSideValidation");
        }

        [HttpPost]
        public ActionResult ServerSideValidation321(ServerValidation sv)
        {
            Debug.WriteLine("Came to post validation" + Request["username"]);
            Dictionary<string, string> errDict = new Dictionary<string, string>();
            if (Request["username"] == "")
            {
                Debug.WriteLine("Came to verify username server side validation");
                errDict.Add("username", "Username cannot be null"); // here the TryGetValue  tries to get the value

            }
            ViewBag.errDict = errDict;
            return View("../Filter/ServerSideValidation");
        }


      


    }
}