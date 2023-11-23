using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capitulo06IdentityMVC.WEB.Areas.Contabilidad.Controllers
{
    [RouteArea("Contabilidad")]
    public class HomeController : Controller
    {
        // GET: Contabilidad/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}