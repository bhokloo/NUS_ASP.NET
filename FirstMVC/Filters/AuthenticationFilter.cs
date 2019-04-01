using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace FirstMVC.Filters
{
    public class AuthenticationFilter : ActionFilterAttribute, IAuthenticationFilter
    {
        private bool isAuthOk = false; 

        public void OnAuthentication(AuthenticationContext ac)
        {

            HttpCookie ssid = HttpContext.Current.Request.Cookies["sessionId"];
            string userid = ssid.Value;
            Debug.WriteLine("ddddddddddddddddddddddd"+userid);
            isAuthOk = (userid == "b6a434c7-faba-4092-ab79-01f146ecc25a");
            Debug.WriteLine(isAuthOk);
            if (isAuthOk != true)
            {
                Debug.WriteLine("fffff");
                ac.Result = new RedirectToRouteResult(
                   new System.Web.Routing.RouteValueDictionary {
                        { "controller", "Home"},
                        { "action", "index"}
                   });
            }
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext acc)
        {
           
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