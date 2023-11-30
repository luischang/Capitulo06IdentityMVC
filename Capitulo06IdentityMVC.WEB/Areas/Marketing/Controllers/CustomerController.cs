using Capitulo06IdentityMVC.CORE.Model;
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

        public ActionResult List(int pageNumber = 1, int pageSize = 10, string searchText = "")
        {
            //var customers = _customerRepository.GetAll();
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

            var customers = string.IsNullOrEmpty(searchText) ?
                            _customerRepository.GetPaged(pageNumber, pageSize) :
                            _customerRepository.GetPagedByLastName(pageNumber, pageSize, searchText);

            var customerList = customers.Select(item => new CustomerViewModel
            {
                Id = item.Id,
                FirstName = item.FirstName,
                LastName = item.LastName,
                Country = item.Country,
                City = item.City,
                Phone = item.Phone
            }).ToList();

            var totalCustomers = string.IsNullOrEmpty(searchText) ?
                                    _customerRepository.GetAll().Count() :
                                    _customerRepository.GetCountByLastName(searchText);


            ViewBag.TotalPages = (int)Math.Ceiling((double)totalCustomers / pageSize);
            ViewBag.TotalRows = totalCustomers;

            return PartialView(customerList);
        }
        //Insert or Update
        public JsonResult Save(CustomerViewModel customerViewModel)
        {
            bool isSuccess = true;

            try
            {
                if (customerViewModel.Id == -1)
                {
                    //Es un nuevo registro
                    var customer = new Customer()
                    {
                        FirstName = customerViewModel.FirstName,
                        LastName = customerViewModel.LastName,
                        City = customerViewModel.City,
                        Country = customerViewModel.Country,
                        Phone = customerViewModel.Phone
                    };

                    _customerRepository.Add(customer);
                }
                else
                {
                    //Un cliente existente
                    var customer = new Customer()
                    {
                        Id = customerViewModel.Id,
                        FirstName = customerViewModel.FirstName,
                        LastName = customerViewModel.LastName,
                        City = customerViewModel.City,
                        Country = customerViewModel.Country,
                        Phone = customerViewModel.Phone
                    };

                    _customerRepository.Update(customer);
                }

            }
            catch (Exception ex)
            {
                isSuccess = false;
            }
            return Json(isSuccess);

        }

        public JsonResult GetCustomer(int id)
        {
            var customer = _customerRepository.GetById(id);
            var customerViewModel = new CustomerViewModel()
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Country = customer.Country,
                City = customer.City,
                Phone = customer.Phone
            };
            return Json(customerViewModel, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete(int id)
        {
            bool isSuccess = true;
            try
            {
                _customerRepository.Delete(id);
            }
            catch (Exception)
            {

                isSuccess = false;
            }
            return Json(isSuccess, JsonRequestBehavior.AllowGet);
        }
    }
}