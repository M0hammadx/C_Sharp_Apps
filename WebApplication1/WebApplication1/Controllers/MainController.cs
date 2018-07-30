using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("h")]
    public class MainController : Controller
    {
        // GET: Main
        [HttpPost]
       
        public ActionResult Index2(Class1 c1)
        {
            c1.z = c1.x + c1.y;

            return View(c1);
        }
        [Route("")]
        [Route("/")]
        public ActionResult Index2()
        {
           

            return View();
        }

       
        public ActionResult Index()
        {
            List<Class1> l = new List<Class1>();
            Class1 c = new Class1();
            c.x = 1;
            c.y = 1;
            c.z = 1;

            l.Add(c);
            c = new Class1();

            c.x = 2;
            c.y = 2;
            c.z = 2;
            l.Add(c);

            return View(l);
        }
        
    }
}