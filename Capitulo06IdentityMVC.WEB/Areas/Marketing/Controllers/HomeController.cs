using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capitulo06IdentityMVC.WEB.Areas.Marketing.Controllers
{
    [RouteArea("Marketing")]
    public class HomeController : Controller
    {
        // GET: Marketing/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}