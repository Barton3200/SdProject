﻿namespace Logic {
    public class OwnedEntityChange : EntityChange {
        public new virtual User Editedby { get; set; }

        public virtual OwnedEntity OwnedEntity { get; set; }
    }
}