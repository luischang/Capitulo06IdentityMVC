using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capitulo06IdentityMVC.WEB.Areas.Finanzas.Controllers
{
    [RouteArea("Finanzas")]
    public class HomeController : Controller
    {
        // GET: Finanzas/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}