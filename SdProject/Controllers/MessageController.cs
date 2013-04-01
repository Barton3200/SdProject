using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using DataAccess.Repositories;
using Logic;
using SdProject.Models.MessageModels;
using WebMatrix.WebData;

namespace SdProject.Controllers
{
    [Authorize]
    public class MessageController : Controller {

        [HttpGet]
        public ActionResult Create(string updateTargetId) {
            var model = new CreateMessageModel { UpdateTargetId = updateTargetId };
            return (Request.IsAjaxRequest() ? (ActionResult)PartialView("_Create", model) : View("Create", model));               
        }     
        
        [HttpPost]
        public ActionResult Create(CreateMessageModel message) {
            if (ModelState.IsValid) {
                User user;
                List<Message> messages;
                List<OwnedEntity> ownedEntities;
                List<OwnedEntityChange> ownedEntityChanges;
                using (var userRepo = new UserRepository()) {
                     user = userRepo.GetUser(WebSecurity.CurrentUserId);
                     messages = user.Messages;
                     ownedEntities = user.OwnedEntities;
                     ownedEntityChanges = user.OwnedEntityChanges;
                }

                var newMessage = new Message(message.Subject,message.MessageBody,
                                    new OwnedEntity(user, ViewPolicy.Open,
                                        new OwnedEntityChange(Request, user)));
                user.Messages.Add(newMessage);
                user.OwnedEntities.Add(newMessage.OwnedEntity);
                user.OwnedEntityChanges.Add(newMessage.OwnedEntity.OwnedHistory.First());
                user.ObjectState = ObjectState.Modified;
                OperationStatus opStatus;
                using (var messageRepo = new MessageRepository()) {
                    opStatus = messageRepo.InsertOrUpdate(newMessage);
                }
                if(opStatus.WasSuccessful) {
                    return Listing(new List<int> { newMessage.Id });
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
                List<Message> userMessages;
                using (var userRepo = new UserRepository()) {
                    user = userRepo.GetUser(WebSecurity.CurrentUserId);
                }

                Message messageToUpdate;
                OperationStatus opStatus;

                using (var messageRepo = new MessageRepository()) {
                    messageToUpdate = messageRepo.GetMessage(message.MessageId);
                }

                messageToUpdate.Subject = message.Subject;
                messageToUpdate.ObjectState = ObjectState.Modified;

                using (var messageRepo = new MessageRepository()) {
                    opStatus = messageRepo.InsertOrUpdate(messageToUpdate);
                }

                if (opStatus.WasSuccessful) {
                    return PartialView("_DisplayMessageSubject", new DisplayMessageModel { MessageId = message.MessageId, UpdateTargetId = message.UpdateTargetId, Subject = message.Subject, HasEditPermision = true });
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
                List<Message> userMessages;
                using (var userRepo = new UserRepository()) {
                    user = userRepo.GetUser(WebSecurity.CurrentUserId);
                }

                Message messageToUpdate;
                OperationStatus opStatus;

                using (var messageRepo = new MessageRepository())
                {  
                    messageToUpdate = messageRepo.GetMessage(message.MessageId);                             
                }

                messageToUpdate.MessageBody = message.MessageBody;
                messageToUpdate.ObjectState = ObjectState.Modified;

                using (var messageRepo = new MessageRepository()) {
                    opStatus = messageRepo.InsertOrUpdate(messageToUpdate);
                }

                if (opStatus.WasSuccessful) { 
                    return PartialView("_DisplayMessageBody", new DisplayMessageModel { MessageId = message.MessageId, UpdateTargetId = message.UpdateTargetId, MessageBody = message.MessageBody, HasEditPermision = true });
                }
            }
            return PartialView("_EditMessageBody", message);
        }

        public ActionResult Listing(IList<int> messageIds) {
            List<DisplayMessageModel> messages;
            User user = new UserRepository().GetUser(WebSecurity.CurrentUserId);
            using (var messageRepo = new MessageRepository()) {
                messages = messageRepo.Messages.Where(message => messageIds.Any(id => id == message.Id)).ToList().Select(message => new DisplayMessageModel(message, user)).ToList();
            }
            var model = new MessageListingModel { Messages = messages };

            return (Request.IsAjaxRequest() ? (ActionResult)PartialView("_Listing", model) : View("Listing", model));
        }
    }
}
