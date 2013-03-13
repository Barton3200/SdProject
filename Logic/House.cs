using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Logic {
    public class House : IObjectState {
        public House() {}

        public House(int storyCount, int roomCount, double floorSpace, Address address, BaseComponent baseComponent, string heatingType = "None") {
            StoryCount = storyCount;
            RoomCount = roomCount;
            FloorSpace = floorSpace;
            HeatingType = heatingType;
            Address = address;
            BaseComponent = baseComponent;
            ObjectState = ObjectState.Added;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string HeatingType { get; set; }

        [Required]
        [Range(1,int.MaxValue)]
        public int StoryCount { get; set; }

        [Required]
        [Range(1,int.MaxValue)]
        public int RoomCount { get; set; }

        [Required]
        public double FloorSpace { get; set; }

        [Required]
        public virtual Address Address { get; set; }

        [Required]
        public virtual BaseComponent BaseComponent { get; set; }

        [NotMapped]
        public ObjectState ObjectState { get; set; }
    }
}