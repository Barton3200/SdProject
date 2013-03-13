using System.ComponentModel.DataAnnotations.Schema;

namespace Logic {
    public class ViewPolicy : IObjectState {
        public ViewPolicy() {}

        public ViewPolicy(string policy, Entity entity) {
            Policy = policy;
            Entity = entity;
            ObjectState = ObjectState.Added;
        }

        public int Id { get; set; }

        public string Policy { get; set; }

        public virtual Entity Entity { get; set; }

        [NotMapped]
        public ObjectState ObjectState { get; set; }
    }
}