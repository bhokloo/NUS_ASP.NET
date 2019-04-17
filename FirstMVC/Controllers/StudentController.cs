using FirstMVC.Filters;
using FirstMVC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace FirstMVC.Controllers
{
    public class StudentController : Controller
    {

        //Contructor
        public StudentController()
        {
            Debug.WriteLine("Debug okay!");
        }

        


        //__________________________________DICTIONARY_______________________________________________________________


        //Dictionary is a class of collections of Keys and Values.....
        public ActionResult About11111()
        {
            Dictionary<int, string> code = new Dictionary<int, string>();
            code.Add(1, "indrajit");
            code.Add(2, "maurya");
            ViewData["code"] = code;
            return View();

        }



        //Redirect to another action and controller
        public ActionResult About322()
        {
            return RedirectToAction("index","Student"); //return to diferent action method and view

            //return View("Getdepartment3"); to return to some view in the same controller.
        }





        //____________________MODEL BINDING_____________________________________________________

        public ActionResult About(string a)
        {
            return View();

        }


        // Here we bind int Emp_Id with @Html.TextBox("Emp_Id") 
        //Simple Binding with no Action in FORM and no MODEL Created....
        // Here we use parameters to bind.
        [HttpPost]
        public ActionResult About1(int Emp_Id, string Emp_Name, String Emp_Add)
        {
                ViewBag.SucessMessage = "Employee ID  " + Emp_Id +"    "+ "Name :  " + Emp_Name;
                return View();

         }


        ////ANother approach using LAMBDA EXPRESSION a => a* 4;
        //[HttpPost]
        //public ActionResult About198(int Emp_Id, string Emp_Name, String Emp_Add)
        //{
        //    ViewBag.SucessMessage = "Employee ID  " + Emp_Id + "    " + "Name :  " + Emp_Name;
        //    return View();

        //}


        //USING FORM COLLECTION FOR ABOVE CODE.
        [HttpPost]
        public ActionResult About(FormCollection collection)
        {
            var a = Request["Emp_id"];
            var Emp_iD = collection["Emp_Id"].ToString();
            var Emp_Name = collection["Emp_Name"].ToString();
            var Emp_Add = collection["Emp_Add"].ToString();
            ViewBag.SucessMessage = "Employee ID  " + Emp_iD + "    " + "Name :  " + Emp_Name + " a : "+ a;

            return View();

            //what if we add more fileds....the line of codes will increase like hell
            //so to overcome this we go for
            
            //MODEL BINDER

        }

        //get method
        public ActionResult ClientSideValidation(string a)
        {
            Debug.WriteLine("Came to Abouthtmlhelper get method");
            return View();
        }

        //USING HTML HELPER and Model
        [HttpPost]
        public ActionResult AboutHtmlHelper1(ClientValidation emp)
        {
            return View(emp); 
        }


        //UPDATE MODEL CONCEPT (ISVALID)

        [HttpPost]
        public ActionResult AboutPop()
        {
            if (ModelState.IsValid) //ModelState is responsible for Model Data validation.
            {
                Employee emp = new Employee();
                UpdateModel(emp); //update the values in this new instance of class Employee.

                ViewBag.SucessMessage = "Employee ID  " + Request["Emp_iD"] + "    " + "Name :  " + Request["Emp_Name"];

                ViewBag.SucessMessage1 = "Employee ID  " + emp.Emp_Id + "    " + "Name :  " + emp.Emp_Name;

                return View();
            }
            return View();
        }



        //______________________________________FILE___________________________________________________________


        //PASSING IMAGE FROM CONTROLLER TO VIEW | VIEWING IMAGE IN Index PAGE (BYTE ARRAY)
        public ActionResult Index()
        {
            var path = Server.MapPath("~/App_Data/a.png");
            byte[] imageByteData = System.IO.File.ReadAllBytes(path);
            string imageBase64Data = Convert.ToBase64String(imageByteData);
            string imageDataURL = string.Format("data:image;base64,{0}", imageBase64Data);
            ViewBag.ImageData = imageDataURL;

            return View();

        }

        //DISPLAY IMAGE DIRECTLY BY ITS PATH.
        public ActionResult Image()
        {
            var a = Server.MapPath("~/App_Data/a.png");
            return File(a, "Image/jpeg");
        }



        //_________________________________ACTION RESULT________________________________________________________

        //RETUN FILE DIRECTLY BY ITS PATH ANOTHER APPROACH
        public FileResult Image1()
        {
            return File(Url.Content("~/App_Data/abc.jpg"), "Image/jpeg");
        }


        //return HTML content
        public ContentResult contentResult1()
        {
            return Content("<h1>Hello</h1>");

        }

        //return JSON
        public JsonResult JSON()
        {
            var ob = new { id = "name", msg = "aaaaa" }; // anonymous Type..create objects with new keyword without defining class
            object ob1 = new { id = "aaaa", msg = "hello" };
            return Json(ob1, JsonRequestBehavior.AllowGet);
        }


        //Return JavaSCript
        public JavaScriptResult JS()
        {
            var aa = $@"alert('hello')";
            return JavaScript(aa);

        }


        //______________________________REDIRECT________________________________________________________


        // RedirectResult
        public RedirectResult About1()
        {
            //ViewBag.Message = "Your application description page.";
            return Redirect("http://www.google.com");
        }


        //Redirect to some Action in same controller
        public RedirectToRouteResult About22()
        {

            return RedirectToAction("JS");
        }



        //Redirect to some Action in different controller
        public RedirectToRouteResult About4()
        {

            return RedirectToAction("../Home/index");
        }



        //[Route("http/{bcd}")]
        //public HttpStatusCodeResult About14(string bcd)
        //{
        //    string session = GetSessionId();

        //    return new HttpStatusCodeResult(HttpStatusCode.OK);
        //}



   //______________________________RAZOR VIEW_________________________________________________________


        [HttpPost]
        public ActionResult About56(Employee emp)
        {
            ViewBag.SucessMessage1 = "Employee ID  " + emp.Emp_Id + "    " + "Name :  " + emp.Emp_Name;
            ViewBag.Message = "Your application description page.";
            ViewData["emp"] = emp; //same as ViewBag ..in ViewBag we do not cast and in ViewData we cast..
            ViewBag.emp1 = emp; // differnce is that 
            ViewBag.maurya = "maurya";
            ViewData["indra"] = "indra"; // in view var s =ViewData["indra"]  will return indra.
            return View("About");
        }



        // __________________@Model and @model________________________________________________

        //PASSING THE EMPLOYEE OBJECT TO THE VIEW TO ACCESS DIRECTLY USING @Model.emp_Id
        [HttpPost]
        public ActionResult About09(Employee emp)
        {
            ViewBag.SucessMessage1 = "Employee ID  " + emp.Emp_Id + "    " + "Name :  " + emp.Emp_Name;
            ViewBag.Message = "Your application description page.";
            ViewData["emp"] = emp; 
            ViewBag.emp1 = emp;
            ViewBag.maurya = "maurya";
            ViewData["indra"] = "indra"; 
            return View(emp); //this is @Model..in View we embed using @Model.Emp_Id
        }


        //__________________________PARTIAL VIEW__________________________________________________________


        [HttpPost]
        public ActionResult AboutHtmlHelper212(ClientValidation emp)
        {

            ViewBag.emp1 = emp;
            return View(emp);
        }

      


       
    }
}