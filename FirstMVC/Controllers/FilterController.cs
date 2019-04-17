using FirstMVC.Filters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstMVC.Controllers
{
    public class FilterController : Controller
    {
        //_____________________________AUTHENTICATION FILTER________________________________________________

        [AuthenticationFilters] //First it check the authentication..if true comes here else goes to home.
        public ActionResult AuthenticationFilter(string id)
        {
            Debug.WriteLine("dddddddddddd");
            return View("../Student/Department");
        }




        [OutputCache] //this filter invokes ActionFilterAttribute class which further implements IActionFilter & IResultFilter
        [Authorize] //this filter invokes OnAuthorization 
        [HandleError] //implements iException Filter...
        public ActionResult Contact2(int? id, string id1) //url for this can be controller/Contact/hello/world .....so here id = null as it acepts string and id1 = world 
        {
            return null;
        }


        //)__________________________________________ACTION FILTER________________________________________________________

        //....Before Action and then after action and then VIEW..

        [ActionFiltera]
        public ActionResult ActionFiltera(string id)
        {
            Debug.WriteLine("dddddddddddd");
            return View("../Student/Department");
        }

        //___________________________________________RESULT FILTER__________________________________________________________
        //
        // RESULT FILTER :: OnResultExecuting is invoked Before the VIEW () OnResultExecuted is invoked and After the VIEW.............
        //
        [ResultFIler]
        public ActionResult ResultFilter(string id)
        {
            Debug.WriteLine("dddddddddddd");
            return View("../Student/Department");
        }



        //________________________________EXCEPTION FILTER_________________________________________________________
        //
        // The moment exception is encountered, it calls the ExceptionFilter class and returns the Respecive Error View Page
        // and it doesnt return back...
        [ExceptionFilters]
        public ActionResult Exception(string id)
        {
            int a = 1;
            int b = 1;
            Debug.WriteLine(HttpContext.Session.SessionID);
            var k = 1 / (a - b);
            Debug.WriteLine("DDD");
            return View("../Student/Department");
        }

    }
}