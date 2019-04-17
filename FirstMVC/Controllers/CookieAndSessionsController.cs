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


        public ActionResult SessionView()
        {
            return View();
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