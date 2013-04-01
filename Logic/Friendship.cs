using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Logic {
    public class Friendship : IObjectState {
        public Friendship() {}

        public Friendship(User initiator, User reciever, OwnedEntity ownedEntity) {
            Initiator = initiator;
            Reciever = reciever;
            Status = FriendshipStatus.Pending;
            OwnedEntity = ownedEntity;
            ObjectState = ObjectState.Added;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public virtual User Initiator { get; set; }

        [Required]
        public virtual User Reciever { get; set; }

        [Required]
        public FriendshipStatus Status { get; set; }

        [Required]
        public virtual OwnedEntity OwnedEntity { get; set; }

        [NotMapped]
        public ObjectState ObjectState { get; set; }
    }
    public enum FriendshipStatus { 
        Confirmed,
        Pending,
        Blocked
    }
}