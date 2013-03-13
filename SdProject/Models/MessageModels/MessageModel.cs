using System;
using System.Linq;
using Logic;

namespace SdProject.Models.MessageModels {
    public class MessageModel {
        public MessageModel(Message message) {
            Author = message.OwnedEntity.OwnedHistory.First().EditedbyUser.UserName;
            Subject = message.Subject;
            MessageBody = message.MessageBody;
            Created = message.OwnedEntity.OwnedHistory.First().EditedOn;
            LastModified = message.OwnedEntity.OwnedHistory.Last().EditedOn;
            LastModifiedBy = message.OwnedEntity.OwnedHistory.Last().EditedbyUser.UserName;
        }

        public string LastModifiedBy { get; set; }

        public string Author { get; set; }

        public string Subject { get; set; }

        public string MessageBody { get; set; }

        public DateTime Created { get; set; }

        public DateTime LastModified { get; set; }
    }
}