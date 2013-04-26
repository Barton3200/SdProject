using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using DataAccess.Repositories;
using Logic;
using Logic.Helpers;
using SdProject.Models.MessageModels;
using WebMatrix.WebData;
using System;

namespace SdProject.Controllers
{
    [Authorize]
    public class MessageController : Controller {

        [HttpGet]
        public ActionResult Create(string updateTargetId) {
            updateTargetId = String.IsNullOrEmpty(updateTargetId) ? "newMessage" : updateTargetId;
            var model = new CreateMessageModel { UpdateTargetId = updateTargetId };
            return (Request.IsAjaxRequest() ? (ActionResult)PartialView("_CreateMessage", model) : View("Create", model));               
        }     
        
        [HttpPost]
        public ActionResult Create(CreateMessageModel message) {
            if (ModelState.IsValid) {
                User user;
                
                using (var userRepo = new UserRepository()) {
                     user = userRepo.GetUserWithIncludes(WebSecurity.CurrentUserId, x => x.Messages, x => x.UserOwnedEntities, x => x.OwnedEntityChanges);
                }
                user.TrackingEnabled = true;
                var newMessage = new Message(message.Subject,message.MessageBody, user,
                                    new OwnedEntity(user, ViewPolicy.Open,
                                        new OwnedEntityChange(Request, user)));

                OperationStatus opStatus;
                using (var messageRepo = new MessageRepository()) {
                    opStatus = messageRepo.InsertOrUpdate(newMessage);
                }
                if(opStatus.WasSuccessful) {
                    return Display(newMessage.Id);
                }
            }
            return (Request.IsAjaxRequest() ? (ActionResult)PartialView("_Create", message) : View("Create", message));
        }

        public ActionResult Edit(int messageId) {
            EditMessageModel message;
            using (var messageRepo = new MessageRepository())
            {
                message = new EditMessageModel(messageRepo.GetMessage(messageId));
            }
            return View("_Edit", message);
        }

        public ActionResult EditMessageSubject(int messageId, string updateTargetId) {
            if (Request.IsAjaxRequest()) {
                EditMessageSubjectModel message;
                using (var messageRepo = new MessageRepository()) {
                    message = new EditMessageSubjectModel(messageRepo.GetMessage(messageId)) { UpdateTargetId = updateTargetId };
                }
                return PartialView("_EditMessageSubject", message);
            }
            return Edit(messageId);
        }

        [HttpPost]
        public ActionResult EditMessageSubject(EditMessageSubjectModel message) {
            if (ModelState.IsValid) {
                User user;
                using (var userRepo = new UserRepository()) {
                    user = userRepo.GetUser(WebSecurity.CurrentUserId);
                }

                Message messageToUpdate;
                OperationStatus opStatus;

                using (var messageRepo = new MessageRepository()) {
                    messageToUpdate = messageRepo.Get<Message>(x => x.Id == message.MessageId, 
                                                               x => x.OwnedEntity.UserOwnedEntities.Select(uoe => uoe.User.FriendReceptions), 
                                                               x => x.OwnedEntity.UserOwnedEntities.Select(uoe => uoe.User.FriendInitiations));
                }

                if (PermissionHelper.HasEditPermission(messageToUpdate.OwnedEntity, user))
                {
                    messageToUpdate.TrackingEnabled = true;
                    messageToUpdate.Subject = message.Subject;

                    using (var messageRepo = new MessageRepository())
                    {
                        opStatus = messageRepo.InsertOrUpdate(messageToUpdate);
                    }

                    if (opStatus.WasSuccessful)
                    {
                        return PartialView("_DisplayMessageSubject", new MessageDisplayModel { MessageId = message.MessageId, UpdateTargetId = message.UpdateTargetId, Subject = message.Subject, HasEditPermision = true });
                    }
                }
            }
            return PartialView("_EditMessageSubject", message);
        }

        public ActionResult EditMessageBody(int messageId, string updateTargetId) {
            if (Request.IsAjaxRequest())
            {
                EditMessageBodyModel message;
                using (var messageRepo = new MessageRepository())
                {
                    message = new EditMessageBodyModel(messageRepo.GetMessage(messageId)) { UpdateTargetId = updateTargetId };
                }
                return PartialView("_EditMessageBody", message);
            }
            return Edit(messageId);
        }
        
        [HttpPost]
        public ActionResult EditMessageBody(EditMessageBodyModel message) {
            if (ModelState.IsValid) {
                User user;
                using (var userRepo = new UserRepository()) {
                    user = userRepo.GetUser(WebSecurity.CurrentUserId);
                }

                Message messageToUpdate;
                OperationStatus opStatus;

                using (var messageRepo = new MessageRepository())
                {
                    messageToUpdate = messageRepo.Get<Message>(x => x.Id == message.MessageId, x => x.OwnedEntity.UserOwnedEntities.Select(uoe => uoe.User));                             
                }

                if(PermissionHelper.HasEditPermission(messageToUpdate.OwnedEntity, user)) {
                    messageToUpdate.TrackingEnabled = true;
                    messageToUpdate.MessageBody = message.MessageBody;

                    using (var messageRepo = new MessageRepository()) {
                        opStatus = messageRepo.InsertOrUpdate(messageToUpdate);
                    }

                    if (opStatus.WasSuccessful) { 
                        return PartialView("_DisplayMessageBody", new MessageDisplayModel { MessageId = message.MessageId, UpdateTargetId = message.UpdateTargetId, MessageBody = message.MessageBody, HasEditPermision = true });
                    }
                }
            }
            return PartialView("_EditMessageBody", message);
        }

        [ChildActionOnly]
        public ActionResult Listing(IList<int> messageIds) {
            ICollection<Message> messages;
            User user = new UserRepository().GetUser(WebSecurity.CurrentUserId);
            using (var messageRepo = new MessageRepository()) {
                messages = messageRepo.GetAllWithIncludes<Message>(message => messageIds.Any(id => id == message.Id), 
                    x => x.OwnedEntity, 
                    x => x.OwnedEntity.OwnedHistory, 
                    x => x.OwnedEntity.UserOwnedEntities, 
                    x => x.OwnedEntity.OwnedHistory.Select(y => y.EditedbyUser)
                    ).ToList();
            }
            var model = new MessageListingModel { Messages = messages.Select(message => new MessageDisplayModel(message, user)).ToList() };

            return (Request.IsAjaxRequest() ? (ActionResult)PartialView("_Listing", model) : View("Listing", model));
        }

        public ActionResult Display(int messageId) {
            Message message;
            User user = new UserRepository().GetUser(WebSecurity.CurrentUserId);
            using (var messageRepo = new MessageRepository())
            {
                message = messageRepo.Get<Message>(x => x.Id == messageId,
                    x => x.OwnedEntity,
                    x => x.OwnedEntity.OwnedHistory,
                    x => x.OwnedEntity.UserOwnedEntities,
                    x => x.OwnedEntity.OwnedHistory.Select(y => y.EditedbyUser));
            }
            var model = new MessageDisplayModel(message, user);

            return (Request.IsAjaxRequest() ? (ActionResult)PartialView("_DisplayMessageRoot", model) : View("DisplayMessage", model)); 
        }
    }
}
