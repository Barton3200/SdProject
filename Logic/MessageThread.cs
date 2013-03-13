using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Logic {
    public class MessageThread : IObjectState {
        public MessageThread() {}

        public MessageThread(string subject, Message message, User author, BaseComponent baseComponent, OwnedEntity ownedEntity) {
            Subject = subject;
            Messages = new List<Message> { message };
            Author = author;
            BaseComponent = baseComponent;
            OwnedEntity = ownedEntity;
            ObjectState = ObjectState.Added;
        }

        public int Id { get; set; }

        public string Subject { get; set; }

        public virtual List<Message> Messages { get; set; }

        public virtual User Author { get; set; }

        public virtual BaseComponent BaseComponent { get; set; }

        public virtual OwnedEntity OwnedEntity { get; set; }

        [NotMapped]
        public ObjectState ObjectState { get; set; }
    }
}