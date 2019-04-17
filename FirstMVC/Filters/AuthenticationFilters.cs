using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace FirstMVC.Filters
{
    public class AuthenticationFilters : ActionFilterAttribute, IAuthenticationFilter
    {
        private bool isAuthOk = false; 

        public void OnAuthentication(AuthenticationContext ac)
        {
            Debug.WriteLine("OnAuthentication");
            //HttpCookie ssid = HttpContext.Current.Request.Cookies["sessionId"];
            //string userid = ssid.Value;
            //Debug.WriteLine("ddddddddddddddddddddddd"+userid);
            //isAuthOk = (userid == "99fab039-fc8a-48e6-8910-33a8cd323899");
            //Debug.WriteLine(isAuthOk);
            //if (isAuthOk != true)
            //{
            //    Debug.WriteLine("fffff");
            //    ac.Result = new RedirectToRouteResult(
            //       new System.Web.Routing.RouteValueDictionary {
            //            { "controller", "Home"},
            //            { "action", "index"}
            //       });
            //}
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext acc)
        {
            Debug.WriteLine("OnAuthenticationChallenge");
        }

        public string GetUserId(string sessionId)
        {
            return "";
        }

        public void LoginIntruderAccess()
        {

        } 
    }


}