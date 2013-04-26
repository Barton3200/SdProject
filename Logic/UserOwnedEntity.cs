using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Helpers;

namespace Logic {
    public class UserOwnedEntity: IObjectState, IEquatable<UserOwnedEntity> {

        public UserOwnedEntity() {}

        public UserOwnedEntity(User user, OwnedEntity ownedEntity) {
            TrackingEnabled = true;
            ObjectState = ObjectState.Added;
            UserId = user.Id;
            User = user;
            OwnedEntityId = ownedEntity.Id;
            OwnedEntity = ownedEntity;
        }
        
        #region Backing Fields
        private int _userId;
        private User _user;
        private int _ownedEntityId;
        private OwnedEntity _ownedEntity;
        #endregion

        public int UserId {
            get { return _userId; }
            set { _userId = ChangeTracker.Set(this, UserId, value); }
        }

        [ForeignKey("UserId")]
        public User User {
            get { return _user; }
            set { _user = ChangeTracker.Set(this, User, value); }
        }

        public int OwnedEntityId {
            get { return _ownedEntityId; }
            set { _ownedEntityId = ChangeTracker.Set(this, OwnedEntityId, value); }
        }

        [ForeignKey("OwnedEntityId")]
        public OwnedEntity OwnedEntity {
            get { return _ownedEntity; }
            set { _ownedEntity = ChangeTracker.Set(this, OwnedEntity, value); }
        }

        [NotMapped]
        public ObjectState ObjectState { get; set; }

        [NotMapped]
        public bool TrackingEnabled { get; set; }

        public bool Equals(UserOwnedEntity other) {
            return UserId == other.UserId && OwnedEntityId == other.OwnedEntityId;
        }
    }
}
