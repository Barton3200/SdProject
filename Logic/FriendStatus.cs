using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Logic {
    public class FriendStatus : IObjectState {
        public FriendStatus() {}

        public FriendStatus(string value, Entity entity) {
            Value = value;
            Entity = entity;
            ObjectState = ObjectState.Added;
        }

        [Key]
        public int Id { get; set; }

        public string Value { get; set; }

        [Required]
        public virtual Entity Entity { get; set; }

        [NotMapped]
        public ObjectState ObjectState { get; set; }
    }
}