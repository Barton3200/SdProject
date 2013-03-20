using System;
using System.Linq;
using Logic;

namespace SdProject.Models.MessageModels {
    public class DisplayMessageModel 
    {
        public DisplayMessageModel(Message message) 
        {
            MessageId = message.Id;
            Author = message.OwnedEntity.OwnedHistory.First().EditedbyUser.UserName;
            Subject = message.Subject;
            MessageBody = message.MessageBody;
            Created = message.OwnedEntity.OwnedHistory.First().EditedOn;
            LastModified = message.OwnedEntity.OwnedHistory.Last().EditedOn;
            LastModifiedBy = message.OwnedEntity.OwnedHistory.Last().EditedbyUser.UserName;
        }
        public int MessageId { get; set; }

        public string LastModifiedBy { get; set; }

        public string Author { get; set; }

        public string Subject { get; set; }

        public string MessageBody { get; set; }

        public DateTime Created { get; set; }

        public DateTime LastModified { get; set; }
    }
}