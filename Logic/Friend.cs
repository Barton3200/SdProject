using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Logic {
    public class Friend : IObjectState {
        public Friend() {}

        public Friend(User initiator, User reciever, OwnedEntity ownedEntity) {
            Initiator = initiator;
            Reciever = reciever;
            OwnedEntity = ownedEntity;
            ObjectState = ObjectState.Added;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public virtual User Initiator { get; set; }

        [Required]
        public virtual User Reciever { get; set; }

        public virtual FriendStatus Status { get; set; }

        [Required]
        public virtual OwnedEntity OwnedEntity { get; set; }

        [NotMapped]
        public ObjectState ObjectState { get; set; }
    }
}