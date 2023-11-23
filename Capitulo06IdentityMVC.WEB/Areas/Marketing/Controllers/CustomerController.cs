using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capitulo06IdentityMVC.WEB.Areas.Marketing.Controllers
{
    [RouteArea("Marketing")]
    public class CustomerController : Controller
    {
        // GET: Marketing/Customer
        public ActionResult Index()
        {
            return View();
        }
    }
}