using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;
using System.Web;

namespace Logic {
    public class EntityChange : IObjectState {
        public EntityChange() {}

        public EntityChange(HttpRequestBase request) {
            Editedby = request.UserHostName;
            IpAddress = request.UserHostAddress;
            UserAgent = request.UserAgent;
            EditedOn = DateTime.Now;
            ObjectState = ObjectState.Added;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Editedby { get; set; }

        [Required]
        public string IpAddress { get; set; }

        [Required]
        public string UserAgent { get; set; }

        [Required]
        public DateTime EditedOn { get; set; }

        [Required]
        public virtual Entity Entity { get; set; }

        [NotMapped]
        public ObjectState ObjectState { get; set; }
    }
}