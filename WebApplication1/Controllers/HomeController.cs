using System;
using System.Reflection;
using System.Web.Mvc;
using ClassLibrary1;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        { 
            return View();
        }

        [HttpPost]
        public ActionResult Index(string action)
        {
            if (action == "Get one")
            {
                var people = new People();
                var id = people.GetInfo();
                //var poem = new Poems();
            }
            else if (action == "getReport")
            {
                
            }


            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class MultiButtonAttribute : ActionNameSelectorAttribute
    {
        public string MatchFormKey { get; set; }
        public string MatchFormValue { get; set; }
        public override bool IsValidName(ControllerContext controllerContext, string actionName, MethodInfo methodInfo)
        {
            return controllerContext.HttpContext.Request[MatchFormKey] != null &&
                   controllerContext.HttpContext.Request[MatchFormKey] == MatchFormValue;
        }
    }
}