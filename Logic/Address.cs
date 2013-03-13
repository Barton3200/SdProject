using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Logic {
    public class Address : IObjectState {
        public Address() {}

        public Address(string streetAddress, string streetAddress2, string city, string state, string zipCode,
                             OwnedEntity ownedEntity) {
            StreetAddress = streetAddress;
            StreetAddress2 = streetAddress2;
            City = city;
            State = state;
            ZipCode = zipCode;
            OwnedEntity = ownedEntity;
            ObjectState = ObjectState.Added;
        }

        [Key]
        public int Id { get; set; }

        public string StreetAddress { get; set; }

        public string StreetAddress2 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }

        [Required]
        public  virtual OwnedEntity OwnedEntity { get; set; }

        [NotMapped]
        public ObjectState ObjectState { get; set; }
    }
}