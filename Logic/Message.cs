using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Logic {
    public class Message : IObjectState {
        public Message() {}

        public Message(string subject, string messageBody, OwnedEntity ownedEntity) {
            Subject = subject;
            MessageBody = messageBody;
            OwnedEntity = ownedEntity;
            ObjectState = ObjectState.Added;
        }

        public int Id { get; set; }

        [Required, MinLength(1)]
        public string MessageBody { get; set; }

        [Required, MinLength(1)]
        public string Subject { get; set; }

        public virtual OwnedEntity OwnedEntity { get; set; }

        [NotMapped]
        public ObjectState ObjectState { get; set; }
    }
}