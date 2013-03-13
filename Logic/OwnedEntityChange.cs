using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace Logic {
    public class OwnedEntityChange : IObjectState {
        public OwnedEntityChange() {
        }

        public OwnedEntityChange(HttpRequestBase request, User user) {
            IpAddress = request.UserHostAddress;
            UserAgent = request.UserAgent;
            EditedOn = DateTime.Now;
            EditedbyUser = user;
            ObjectState = ObjectState.Added;
        }

        public int Id { get; set; }

        [Required]
        public string IpAddress { get; set; }

        [Required]
        public string UserAgent { get; set; }

        [Required]
        public DateTime EditedOn { get; set; }

        [Required]
        public virtual User EditedbyUser { get; set; }

        [Required]
        public virtual OwnedEntity OwnedEntity { get; set; }

        [NotMapped]
        public ObjectState ObjectState { get; set; }
    }
}
