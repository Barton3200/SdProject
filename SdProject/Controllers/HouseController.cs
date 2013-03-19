using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Logic;
using DataAccess.Repositories;
using WebMatrix.WebData;
using SdProject.Filters;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SdProject.Controllers
{
    [Authorize]
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
        public ActionResult EnterInfo(SdProject.Models.HouseDisplayModel.EnterInfo house)
        {
            if (ModelState.IsValid)
            {
                User user;
                using (var userRepo = new UserRepository())
                {
                    user = userRepo.GetUser(WebSecurity.CurrentUserId);
                }
                var newHouse = new House(   house.streetAddress,
                                            house.city,
                                            house.zipCode,
                                            house.style,
                                            house.floorSpace,
                                            house.roomCount,
                                            house.storyCount,
                                            house.bedrooms,
                                            house.bathrooms,
                                            house.extras,
                                            new BaseComponent( new OwnedEntity(user, new OwnedEntityChange(Request, user))),
                                            house.heatingType);

            }
            return RedirectToAction("UploadImage", "House");
        }

        public ActionResult UploadImage()
        {
            return View();
        }
        
    }
}
