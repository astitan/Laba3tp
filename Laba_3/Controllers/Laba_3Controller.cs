using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Laba_3.Controllers
{
    public class HomeController : IController
    {
        public void Execute(RequestContext requestContext)
        {
            string action = requestContext.RouteData.Values["action"].ToString();
            int id = 1;
            if (requestContext.RouteData.Values["id"] != null)
            {
                bool bool_id = Int32.TryParse(requestContext.RouteData.Values["id"].ToString(), out id);
            }

            if (action == "start" && id == 0)
            {
                requestContext.HttpContext.Response.Redirect("/Data/Person");
            }
            else
            {
                requestContext.HttpContext.Response.Write("Ошибка. ");
                requestContext.HttpContext.Response.Write("URL: " + requestContext.HttpContext.Request.Url.ToString());
            }
        }
    }

    public class DataController : Controller
    {
        public ActionResult Person()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Person(string name, DateTime Date_Birth, int? id_Person, string phone, bool work)
        {
            if (id_Person != null)
            {
                ViewBag.Name = name;
                ViewBag.Date_Birth = Date_Birth;
                ViewBag.Gender = Request.Form["gender"];
                ViewBag.Id = id_Person.Value;
                ViewBag.Telephone = phone;
                ViewBag.Work = work;
                return View("Result");
            }
            else
            {
                return RedirectToRoute(new { controller = "Data", action = "Person" });
            }
        }
        public ActionResult Result()
        {
            return View();
        }
    }

}