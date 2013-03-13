using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic {
    public class OperationStatus<TClass> : OperationStatus where TClass : class, IObjectState, new() {        
        public OperationStatus() {
            EffectedItems = new List<TClass>();
            ItemsObjectState = new List<ObjectState>();
        }
        public List<TClass> EffectedItems { get; set; }
        // The ObjectState before the opertation
        public List<ObjectState> ItemsObjectState { get; set; }

        public void AddEffectedItem(TClass itemToAdd) {
            EffectedItems.Add(itemToAdd);
            ItemsObjectState.Add(itemToAdd.ObjectState);
        }

        public void AddEffectedItems(IEnumerable<TClass> itemsToAdd) {
            foreach (var item in itemsToAdd) {
                AddEffectedItem(item);
            }
        }
    }
    public class  OperationStatus {
        public bool WasSuccessful { get; set; }
        public Exception Exception { get; set; }
    }
}
