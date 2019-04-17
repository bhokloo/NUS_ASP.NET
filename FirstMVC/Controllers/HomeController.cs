using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;
using FirstMVC.Models;

namespace FirstMVC.Controllers
{
    public class HomeController : Controller
    {

        //__________ATTRIBUTE ROUTING works only if specified this  routes.MapMvcAttributeRoutes();________________________________________________________________________


        [Route("users/{a}/{time}/messages")] //this is called Attribute Routing. and this {value} is called RouteData.Values
        public ActionResult Department(int a, string time, string aaa)  // so this can be accessed by http://localhost:54976/users/12/10/messages
        {
            Debug.WriteLine("aaaaaa" + a + " " + time + " " + aaa); //or http://localhost:54976/users/1/2/messages?a=22&time=122&aaa=asd where values of a and time remains 1 and 2 and the value of aaa is asd
                                                                    // But when i provide (int a ,string time, int aaa) i.e only int aaa, it gives null exception so declare like this int? aaa ..note string is passed as null value but not int.

            return View(); //this View will search for Same Department page inside the Views/{controllerName} i.e. Viws/Home/Department.cshtml
        }

        [Route("callme")] //this is called Attribute Routing.
        public ActionResult GetDepartment(string d, string c, int? f) //http://localhost:54976/callme?c=indra&d=maurya&f=1
        {                               // http://localhost:54976/callme?d=maurya&c=indra&f=2 can write both ways.
                                        // if int f, then throws nullable exception so write int? f so it will work even with this url http://localhost:54976/callme where all parameters are null. 
            return View();

        }

        //NOTE : the url after? accepts everyting...like http://localhost:54976/callme?cn=indra&d=maurya&f=1*&y=0@##bdfbdfbdfb will call the above page successfully



        //____________CONVENTION ROUTING_________________________________________________________________________________

        //url for the following will be based on RouteConfig.cs
        // i.e url: "{controller}/{action}/{id}/{id1}"
        //note this controller is defined specifically for HomeController but we can call all others Controllers without specifying it.
        //BUT all follows the pattern and get {id}/{id} by default..

        //Try running other controller to get see that.

        //so, the url for follwing can be : http://localhost:54976/Home/Contact ..
        // RIGHT http://localhost:54976/Home/contact/1/2 because of this {controller}/{action}/{id}/{id1} where id=1 and id1=2 gets assigned
        //WRONG http://localhost:54976/Home/contact/1/2/3 
        //RIGHT http://localhost:54976/home/contact/1/2?d=indra 
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }




        public ActionResult Department(int? a, int? b, int id, int id1) // here ? says it can pass null
        
        // here url can be http://localhost:54976/Home/Department/3/4/?a=1&b=2
        {
            Debug.WriteLine("vvvvvvvvv" + a); //a =1
            Debug.WriteLine("vvvvvvvvv" + b); // b= 2
            Debug.WriteLine("vvvvvvvvv" + id); //id = 3 {from routeConfig} : applicable to all controllers even not defined
            Debug.WriteLine("vvvvvvvvv" + id1); // id1 =4  {from routeConfig}  :: Applicable to all
            return View();
        }



        //by default its GET : [HttpGet]
        public ActionResult Index(int? id)
        {
            return View();
        }


        public ActionResult GetDepartment3(string a) 
        {
            //ViewData["abc"] = new Entity(); //HttpGet Method, passed the null object to bind the View with the refernce object.
          
            var reqC = Request.QueryString["course"]; //request parameters from URL...HTTPGET
            Debug.WriteLine("HttpGet Method of GetDepartment3 "+ reqC);
            return View();
        }

        [HttpPost]
        public ActionResult GetDepartment3(Entity obj) //it holds the parameters values.
        {
            var reqA = Request["department"]; //request the department from POST BODY......Request.QueryString["course"]; will not work here
            Debug.WriteLine("yes the request['departmen'] its taking from not form HTTP POST BODY and not from Enitity obj." + reqA);
            var reqB = Request["course"];
            Debug.WriteLine(reqA+""+reqB);
            ViewData["abc"] = obj; // this ViewData["obj"] = obj; carries the objects to bind it with the view...
            return View();
        }


        //FormCollection
        public ActionResult About(Employee d)
        {

            string sss = Request.Cookies["SessionId"].Value;

            Data data = new Data();
            data.Greeting = "Hello there";
            data.From = "This is Home controller";
            ViewData["data"] = d;
            ViewBag.Message = "Your application description page.";
            ViewBag.Message = d;  
            return View(d);

        }

       
    }
}