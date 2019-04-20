using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;
using FirstMVC.Models;

namespace FirstMVC.Controllers
{
    public class CookieAndSessionsController : Controller
    {
        //___________________________SESSIONS AND COOKIE___________________________________________________________

        //CHER WAH
        public ActionResult SessionView()
        {
            //var b = Session["ASP.NET_SessionId"];
            var a = Request.Cookies["ASP.NET_SessionId"].Value.ToString(); // Default Cookie...
            var aa = Session["sessionIdname"];
            Debug.WriteLine( a + "  --  " + aa );
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(string username)
        {
            if (username == null)
                return View();

            if (Session[username] != null)
                return View();

            string sessionId = Guid.NewGuid().ToString();
            Session[username] = sessionId;
            Session[sessionId] = username;
            Session[sessionId + "_run"] = new List<string>();

            return RedirectToAction("Track", new { sessionId = sessionId });
        }


        public ActionResult Track(string sessionId, string cmd, string history)
        {

            ViewData["sessionId"] = sessionId;

            if (cmd == "Get")
            {
                List<string> running = (List<string>)Session[sessionId + "_run"];
                ViewData["history"] = String.Join(", ", running.ToArray());
                return View();
            }

            if (cmd == "Logout")
            {
                string username = (string)Session[sessionId];
                Session[username] = null;
                Session[sessionId + "_run"] = null;
                return View("login");
            }
            else
            {
                List<string> list = (List<string>)Session[sessionId + "_run"];
                if (cmd != null)
                    list.Add(cmd);
            }

            ViewData["history"] = history;
            return View();
        }




        //CREATING COOKIES
        public ActionResult GetSession()
        {
            ViewBag.Message = "Your contact page.";
            HttpCookie Cookie = new HttpCookie("SessionId"); //key value for sessionId
            Cookie.Value = System.Guid.NewGuid().ToString(); // to generate session 
            Cookie.Path = "/"; //session available after this path
            Response.Cookies.Add(Cookie); //add the available cookie to the client browser
            Debug.WriteLine(Cookie.Value);
            return null;
        }


        // FETCHING COOKIES
        public ActionResult GotCookie()
        {
            string sss = Request.Cookies["SessionId"].Value; //getting the session value from anywhere after the path /(/
            Debug.WriteLine(sss);
            return null;

        }


        //COOKIES EXPIRY
        public ActionResult CookieExpiry()
        {
            Debug.WriteLine(HttpContext.Request.Cookies.Count);
            foreach (string key in HttpContext.Request.Cookies.AllKeys)
            {

                HttpCookie c = HttpContext.Request.Cookies[key];

                c.Expires = DateTime.Now.AddMonths(-1);

                HttpContext.Response.AppendCookie(c);

            }
            return null;
        }


       

        [HttpPost]
        public ActionResult SessionView(string msg)
        {
            if (msg != "hello")
                return Content("");

            if (Session["sessionIdname"] == null) //On this line...ASP.NET_SessionId is the session created by ASP.NET on its own.
                Session["sessionIdname"] = 1; //this is a contruct for ASP.NET_SessionId...

            //the moment we run, ASP.NET_SessionId is created and and this sessionIdname is set to 1.
            //we refresh again, the ASP.NET_SessionId does not change but the value of sessionIdname is incremented.
            //thus it says we greeted.

            //at this stage if one deletes the cookies, then again the ASp.NET_SessionId will change and sesionIdname will be null again.

            //to conclude... the live span of ASP.NETsessionId and construct i.e sessionIdName is same.....

            // This sessionIdName does not store in Cookies,, 
            // ASP.NET_SessionId gets stored in browsers Cookies and this gets removed when we stop applicaiton.
            
            else
                Session["sessionIdname"] = (int)Session["sessionIdname"] + 1;

            Debug.WriteLine(Session["sessionIdname"].ToString());
            if((int)Session["sessionIdname"] == 1)
            return Content(msg + "too");

            return Content("we already greeted");

        }

    }
}