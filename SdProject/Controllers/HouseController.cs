using System.Collections.Generic;
using System.Web.Mvc;
using Logic;
using DataAccess.Repositories;
using SdProject.Models.HouseModels;
using WebMatrix.WebData;

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
        public ActionResult EnterInfo(EnterInfo house)
        {
            if (ModelState.IsValid)
            {
                User user;
                List<House> Houses;
                using (var userRepo = new UserRepository())
                {
                    user = userRepo.GetUser(WebSecurity.CurrentUserId);
                    Houses = user.Houses;
                }
                var newHouse = new House(   house.StreetAddress,
                                            house.City,
                                            house.ZipCode,
                                            house.Style,
                                            house.FloorSpace,
                                            house.RoomCount,
                                            house.StoryCount,
                                            house.Bedrooms,
                                            house.Bathrooms,
                                            house.Extras,
                                            new BaseComponent( new OwnedEntity(user, ViewPolicy.Open, new OwnedEntityChange(Request,  user))),
                                            house.HeatingType);
                Houses.Add(newHouse);
                user.ObjectState = ObjectState.Modified;
                using(var houseRepo = new HouseRepository()){
                    houseRepo.InsertOrUpdate(newHouse);
                }
                return RedirectToAction("PageView", "Account");
            }
            return View("EnterInfo", house);
        }

        public ActionResult House(int houseid)
        {
            HouseDisplayModel house;
            using(var houserepo = new HouseRepository())
            {
                house = new HouseDisplayModel(houserepo.GetHouse(houseid));
            }
            return View("_House", house);
        }
        
    }
}
