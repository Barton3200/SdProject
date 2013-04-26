using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Logic.Helpers;

namespace Logic {
    public class Message : IObjectState, IEquatable<Message> {
       
        public Message() {}

        public Message(string subject, string messageBody, User author, OwnedEntity ownedEntity) {
            TrackingEnabled = true;
            ObjectState = ObjectState.Added;
            Subject = subject;
            author.AddMessage(this);
            MessageBody = messageBody;
            OwnedEntityId = ownedEntity.Id;
            OwnedEntity = ownedEntity;
        }

        #region Backing Fields
        private string _messageBody;
        private string _subject;
        private OwnedEntity _ownedEntity;
        private int _ownedEntityId;

        #endregion

        public int Id { get; set; }

        [Required, MinLength(1)]
        public string MessageBody {
            get  { return _messageBody; }
            set { _messageBody = ChangeTracker.Set(this, MessageBody, value); }
        }

        [Required, MinLength(1)]
        public string Subject {
            get { return _subject; }
            set { _subject = ChangeTracker.Set(this, Subject, value); }
        }

        public int OwnedEntityId {
            get { return _ownedEntityId; }
            set { _ownedEntityId = ChangeTracker.Set(this, OwnedEntityId, value); }
        }

        [ForeignKey("OwnedEntityId")]
        public virtual OwnedEntity OwnedEntity {
            get { return _ownedEntity; }
            set { _ownedEntity = ChangeTracker.Set(this, OwnedEntity, value); }
        }

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        [NotMapped]
        public ObjectState ObjectState { get; set; }

        [NotMapped]
        public bool TrackingEnabled { get; set; }

        public bool Equals(Message other) {
            return Id == other.Id;
        }
    }
}