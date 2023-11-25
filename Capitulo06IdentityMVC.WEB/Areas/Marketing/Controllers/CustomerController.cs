using Capitulo06IdentityMVC.CORE.Repository;
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
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        // GET: Marketing/Customer
        public ActionResult Index()
        {
            ViewBag.CustomerList = _customerRepository.GetAll();
            return View();
        }
    }
}