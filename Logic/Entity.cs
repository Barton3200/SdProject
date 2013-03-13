using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Logic {
    public class Entity : IObjectState {
        public Entity() {}

        public Entity(HttpRequestBase request) {
            History = new List<EntityChange> { new EntityChange(request) };
            ObjectState = ObjectState.Added;
        }

        [Key]
        public int Id { get; set; }

        public virtual List<EntityChange> History { get; set; }

        [NotMapped]
        public ObjectState ObjectState { get; set; }
    }
}