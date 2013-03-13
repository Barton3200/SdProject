using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Logic {
    public class BaseComponent : IObjectState {
        public BaseComponent() {}

        public BaseComponent(OwnedEntity ownedEntity) {
            Threads = new List<MessageThread>();
            Images = new List<Image>();
            OEntity = ownedEntity;
            ObjectState = ObjectState.Added;
        }

        [Key]
        public int Id { get; set; }

        public virtual List<MessageThread> Threads { get; set; }

        public virtual List<Image> Images { get; set; }

        [Required]
        public virtual OwnedEntity OEntity { get; set; }

        [NotMapped]
        public ObjectState ObjectState { get; set; }
    }
}