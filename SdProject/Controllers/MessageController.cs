﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess;
using DataAccess.IRepositories;
using DataAccess.Repositories;
using Logic;
using SdProject.Filters;
using SdProject.Models.MessageModels;
using WebMatrix.WebData;

namespace SdProject.Controllers
{
    [Authorize]
    public class MessageController : Controller {

        [HttpGet]
        public ActionResult Create() {
            return PartialView("_Create");
        }

        [HttpPost]
        public ActionResult Create(CreateMessageModel message) {
            if (ModelState.IsValid) {
                User user;
                using (var userRepo = new UserRepository()) {
                     user = userRepo.GetUser(WebSecurity.CurrentUserId);
                }

                var newMessage = new Message(message.Subject,message.MessageBody,
                                    new OwnedEntity(user, 
                                        new OwnedEntityChange(Request, user)));
                using (var messageRepo = new MessageRepository()) {
                    messageRepo.InsertOrUpdate(newMessage);
                }
                return Listing(new List<int> { newMessage.Id });
            }
            return PartialView("_Create");
        }


        public ActionResult Listing(IList<int> messageIds) {
            List<DisplayMessageModel> messages;
            using (var messageRepo = new MessageRepository()) {
                messages = messageRepo.Messages.Where(message => messageIds.Any(id => id == message.Id)).ToList().Select(message => new DisplayMessageModel(message)).ToList();
            }
            var model = new MessageListingModel { Messages = messages };
            if (Request.IsAjaxRequest())
            {
                return PartialView("_Listing", model);
            }
            else
            {
                return View("Listing", model);
            }
        }
    }
}
