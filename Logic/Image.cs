using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Logic {
    public class Image : IObjectState {
        public Image() {}

        public Image(string url, OwnedEntity ownedEntity) {
            Url = url;
            OwnedEntity = ownedEntity;
            ObjectState = ObjectState.Added;
        }

        public int Id { get; set; }

        [Required]
        public string Url { get; set; }

        [Required]
        public virtual OwnedEntity OwnedEntity { get; set; }

        [NotMapped]
        public ObjectState ObjectState { get; set; }
    }
}