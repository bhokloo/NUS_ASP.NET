using FirstMVC.DAO;
using FirstMVC.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstMVC.Controllers
{
    public class ADONETController : Controller
    {
        // DATA TABLE
        public ActionResult ViewDAo()
        {
            List<DAOModelOfMyOwn> daoObject = Dao.AddUsers();
            ViewBag.data = daoObject;
            return View();
        }

        //WEBGRID VIEW
        public ActionResult DisplayDataSetAndGridView()
        {
            List<DAOModelOfMyOwn> ds = Dao.AddUsers();
            return View(ds);
        }


        public ActionResult insert()
        {
            Dao.InsertAgainUsingDataSet();
            return null;
        }

        public ActionResult SQLParameter()
        {
            DAOModelOfMyOwn ob = new DAOModelOfMyOwn();
            ob.customer_id = 1;
            ob.firstname = "lala";
            ob.password = "lala";
            ob.session_id = "lala";
            ob.username = "lala";
            ob.lastname = "ffdfs";

            Dao.ParameterBinding(ob);
            return null;
        }


        
        public ActionResult CallSqlDataAdapter()
        {
            DataTable ds= Dao.DataAdapter();
            return View(ds);
        }


        public ActionResult SQLParameterWithSQlAdapter()
        {
            DAOModelOfMyOwn ob = new DAOModelOfMyOwn();
            ob.customer_id = 13121;
            ob.firstname = "eeeelalfdfda";
            ob.password = "elalgfdga";
            ob.session_id = "eeelfgdfgala";
            ob.username = "eelalfdgdfa";
            ob.lastname = "eeffddfgdfgfs";

            Dao.SQLParameterWithSQlAdapter(ob);
            return View("CallSqlDataAdapter");
        }

        public ActionResult DisplayDataSet()
        {
            DataSet ds = Dao.reading();
            Debug.WriteLine(ds);
            return View(ds);
        }


       
    }
}