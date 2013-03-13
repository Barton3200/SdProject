using System.Data.Entity.ModelConfiguration.Conventions;
using Logic;
using System.Data.Entity;

namespace DataAccess
{
    public class SdDb : DbContext 
    {       
        public SdDb() : base("name = " + AppConfig.GetActiveConnectionString()) {
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<BaseComponent> Components { get; set; }
        public DbSet<Entity> Entities { get; set; }
        public DbSet<EntityChange> EntityChanges { get; set; }
        public DbSet<Friend> Friends { get; set; }
        public DbSet<FriendStatus> FriendStatuses { get; set; } 
        public DbSet<House> Houses { get; set; }
        public DbSet<Image> Images { get; set; }        
        public DbSet<Message> Messages { get; set; }
        public DbSet<MessageThread> MessageThreads { get; set; }
        public DbSet<OwnedEntity> OwnedEntities { get; set; }
        public DbSet<OwnedEntityChange> OwnedEntityChanges { get; set; } 
        public DbSet<User> Users { get; set; }
        public DbSet<ViewPolicy> ViewPolicies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}
