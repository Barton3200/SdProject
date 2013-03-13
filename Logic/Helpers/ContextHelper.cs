using System.Data.Entity;

namespace Logic.Helpers {
    public static class ContextHelper {
        public static void ApplyStateChanges(this DbContext context) {
            foreach (var entry in context.ChangeTracker.Entries<IObjectState>()) {
                IObjectState entity = entry.Entity;
                entry.State = ObjectStateHelper.ConvertState(entity.ObjectState);
            }
        }
    }
}
