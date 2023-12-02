using Capitulo06IdentityMVC.CORE.Model;
using Capitulo06IdentityMVC.CORE.Repository;
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
        private readonly IMessageRepository _messageRepository;

        public HomeController(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }
        // GET: Marketing/Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Chat() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult InsertMessage(Message message)
        {
            bool isSuccess = true;
            try
            {
                _messageRepository.InsertMessage(message);
            }
            catch (Exception)
            {
                isSuccess = false;
            }

            return Json(new { success = isSuccess });
        }

        [HttpGet]
        public ActionResult GetGroupHistory(string groupName)
        {
            var history = _messageRepository.GetGroupMessages(groupName);
            return Json(history, JsonRequestBehavior.AllowGet);
        }
    }
}