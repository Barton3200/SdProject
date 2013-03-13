using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Logic {
    public class User : IObjectState {
        public User() {}

        public User(string userName, Entity entity, Address address = null) {
            UserName = userName;
            Entity = entity;
            PrimaryAddress = address;
            ObjectState = ObjectState.Added;
        }

        public int Id { get; set; }

        public string UserName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public virtual List<House> Houses { get; set; }

        public virtual Address PrimaryAddress { get; set; }

        public virtual List<Friend> Friends { get; set; }

        public virtual List<Image> Images { get; set; }

        public virtual List<MessageThread> MessageThreads { get; set; }

        public virtual List<Message> Messages { get; set; }

        public virtual List<OwnedEntity> OwnedEntities { get; set; }

        public virtual List<OwnedEntityChange> OwnedEntityChanges { get; set; }

        public virtual Entity Entity { get; set; }

        [NotMapped]
        public ObjectState ObjectState { get; set; }
    }
}

