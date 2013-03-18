using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SdProject.Controllers
{
    public class HouseController : Controller
    {
        //
        // GET: /House/

        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult EnterInfo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EnterInfo(SdProject.Models.HouseDisplayModel.EnterInfo model)
        {
            return RedirectToAction("PageView", "Account");
        }
    }
}
