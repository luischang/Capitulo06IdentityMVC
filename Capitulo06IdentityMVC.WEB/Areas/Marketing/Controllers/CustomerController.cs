using Capitulo06IdentityMVC.CORE.Repository;
using Capitulo06IdentityMVC.WEB.Models;
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
            return View();
        }

        public ActionResult List()
        {
            var customers = _customerRepository.GetAll();
            //var customerList = new List<CustomerViewModel>();
            //foreach (var item in customers)
            //{
            //    var customer = new CustomerViewModel();
            //    customer.Id = item.Id;
            //    customer.FirstName = item.FistName;
            //    customer.LastName = item.LastName;
            //    customer.Country = item.Country;
            //    customer.City = item.City;
            //    customer.Phone = item.Phone;

            //    customerList.Add(customer);
            //}

            var customerList = customers.Select(item => new CustomerViewModel
            {
                Id = item.Id,
                FirstName = item.FirstName,
                LastName = item.LastName,
                Country = item.Country,
                City = item.City,
                Phone = item.Phone
            }).ToList();

            return PartialView(customerList);
        }
    }
}