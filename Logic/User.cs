using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Logic {
    public class User : IObjectState {
        public User() {}

        public User(string email, string userName, Entity entity, Address address = null) {
            Email = email;
            UserName = userName;
            Entity = entity;
            PrimaryAddress = address;
            ObjectState = ObjectState.Added;
        }

        public int Id { get; set; }

        [EmailAddress]
        [MaxLength(100, ErrorMessage = "Username cannot be longer that 100 characters")]
        public string Email { get; set; }

        [MaxLength(100, ErrorMessage = "Username cannot be longer that 100 characters")]
        public string UserName { get; set; }

        public virtual List<House> Houses { get; set; }

        public virtual Address PrimaryAddress { get; set; }

        public virtual List<Friendship> Friends { get; set; }

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

